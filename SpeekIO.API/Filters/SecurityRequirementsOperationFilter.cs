using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace SpeekIO.API.Filters
{
    public class SecurityRequirementsOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
            {
                operation.Parameters = new List<IParameter>();
            }

            var authorizeAttributes = context.ApiDescription
                .ControllerAttributes()
                .Union(context.ApiDescription.ActionAttributes())
                .OfType<AuthorizeAttribute>();
            var allowAnonymousAttributes = context.ApiDescription.ActionAttributes().OfType<AllowAnonymousAttribute>();

            if (!authorizeAttributes.Any() && !allowAnonymousAttributes.Any())
            {
                return;
            }

            var parameter = new NonBodyParameter
            {
                Name = "Authorization",
                In = "header",
                Description = "The bearer token",
                Required = true,
                Type = "string"
            };

            operation.Parameters.Add(parameter);
        }
    }

}
