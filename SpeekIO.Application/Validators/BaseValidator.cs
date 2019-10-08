using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SpeekIO.Application.Validators
{
    public abstract class BaseValidator<T> : AbstractValidator<T>
    {
        public bool ValidateUrl(string url)
        {
            return Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute);
        }

        public bool ValidatePhone(string phone)
        {
            Regex regex = new Regex("^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\\s\\./0-9]*$");

            return regex.IsMatch(phone);
        }

        public bool PasswordValidation(string password)
        {
            // TODO: Define password criteria
            return true;
        }
    }
}
