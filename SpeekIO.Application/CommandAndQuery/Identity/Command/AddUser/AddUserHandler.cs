using AutoMapper;
using EasyBooking.Application.CommandAndQuery.Identity.Command.AddUser.Dto;
using EasyBooking.Domain.Entities.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SpeekIO.Application.Commands;
using SpeekIO.Application.Configuration;
using SpeekIO.Application.Interfaces;
using SpeekIO.Domain.Entities.Identity;
using SpeekIO.Domain.Intefaces.Email;
using SpeekIO.Domain.Interfaces.Email;
using SpeekIO.Domain.Models.Email;
using SpeekIO.Presistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using SpeekIO.Domain.Entities.Portfolio;
using EasyBooking.Common.Session;

namespace EasyBooking.Application.CommandAndQuery.Identity.Command.AddUser
{
	public class AddUserHandler : CommandHandlerBase<AddUserCommand, AddUserResponse>
	{
		private readonly SpeekIOContext _context;
		private readonly IMapper _mapper;
		private readonly IUserSession _userSession;
		private readonly IApplicationConfiguration _applicationConfiguration;
		private readonly IEmailService _emailService;

		public AddUserHandler(
			 SpeekIOContext context,
			IMapper mapper,
			IEmailService emailService,
			IUserSession userSession,
			IApplicationConfiguration applicationConfiguration,
			ApplicationUserManager userManager,
			IHttpContextAccessor httpContextAccessor) : base(userManager, httpContextAccessor)
		{
			_context = context;
			_mapper = mapper;
			_userSession = userSession;
			_applicationConfiguration = applicationConfiguration;
			_emailService = emailService;
		}
		public override async Task<AddUserResponse> Handle(AddUserCommand request, CancellationToken cancellationToken)
		{

			if (request.UserId > 0)
			{
				var assignedRoles = await _context.ApplicationUserRole.Where(t => t.UserId == request.UserId).ToListAsync();
				if (request.SelectedRoles.Any())
				{
					assignedRoles.ForEach(item =>
					{
						item.IsDeleted = true;
					});
					request.SelectedRoles.ForEach(item =>
					{
						var assigned = assignedRoles.FirstOrDefault(t => t.RoleId == item.Id);
						if (assigned == null)
						{
							var newRole = new ApplicationUserRole()
							{
								RoleId = item.Id,
								UserId = request.UserId,
								CreatedOn = DateTime.UtcNow,
								CreatedBy = User.Id
							};
							_context.ApplicationUserRole.Add(newRole);
						}
						else
						{
							assigned.IsDeleted = false;
						}

						if (assigned != null && assigned.IsDeleted)
						{
							assigned.ModifiedOn = DateTime.UtcNow;
							assigned.ModifiedBy = User.Id;
						}
					});
					await _context.SaveChangesAsync(User);
				}
			}
			else
			{
				var existingUser = await _userManager.FindByEmailAsync(request.Email);
				if (existingUser != null)
					return new AddUserResponse()
					{
						Successful = false,
						Message = "Email already exists."
					};

				var user = _mapper.Map<ApplicationUser>(request);
				user.LockoutEnabled = true;
				user.UserName = request.Email;

				var identityResult = await _userManager.CreateAsync(user, _applicationConfiguration.DefaultPassword);
				if (!identityResult.Succeeded || 0 >= user.Id)
					return new AddUserResponse()
					{
						Successful = false,
						Message = "Something went wrong while creating a user."
					};
				await AssignRoles(user, request);
				await CreateProfile(request, user);
				await SendActivationEmail(user);
			}


			return new AddUserResponse()
			{
				Successful = true,
				Message = "User added successfully."
			};
		}

		//method to assign roles to user
		private async Task AssignRoles(ApplicationUser user, AddUserCommand request)
		{
			var roles = new List<string>();
			request.SelectedRoles.ForEach(item =>
			{
				roles.Add(item.Name);
			});

			await _userManager.AddToRolesAsync(user, roles);
			await _userManager.UpdateAsync(user);
		}

		//method to create profile for user
		private async Task CreateProfile(AddUserCommand request, ApplicationUser user)
		{
			try
			{
				var profile = _mapper.Map<SpeekIO.Domain.Entities.Portfolio.Profile>(request);
				profile.Id = user.Id;
				profile.UserId = user.Id;
				if(_userSession.CompanyId <= 0)
					profile.CompanyId = _context.Profiles.Where(x => x.Email == _applicationConfiguration.DefaultCompanyEmail).FirstOrDefault().CompanyId;
				profile.CompanyId = _userSession.CompanyId;
				_context.Profiles.Add(profile);
				await _context.SaveChangesAsync(User);
			}

			catch(Exception ex)
			{
				throw ex;
			}
		}

		//method to send activation email
		private async Task SendActivationEmail(ApplicationUser user)
		{
			var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
			var activationUrl = $"{_applicationConfiguration.ClientAppUrl}/{_applicationConfiguration.EmailVerificationPageUrl}?email={user.Email}&token={HttpUtility.UrlEncode(token)}";
			IRecipient recipient = new Recipient(user.UserName, user.Email);
			IEmailModel emailModel = new AccountActivationEmailModel(activationUrl, recipient);
			emailModel.TemplateName = "AccountActivationWithLink";
			await _emailService.SendEmailAsync(emailModel);
		}
	}
}
