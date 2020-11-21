using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Afi.CustomerRegistration.Web.Models;
using System.Text.RegularExpressions;

namespace Afi.CustomerRegistration.Web.Validators
{
    /// <summary>
    /// TODO:RK This can be refactored and put ina separate project as as the application builds up. I 
    /// I could have used Attributes to validate the request, however wanted to demonstrate Fluent validation
    /// as this also very popular. Write tests for the validator.
    /// </summary>
    public class CreateCustomerRequestValidator : AbstractValidator<CreateCustomerRequest>
    {
        public CreateCustomerRequestValidator()
        {
            RuleFor(x => x.FirstName).NotNull().NotEmpty().Length(3, 50).WithMessage("Firstname is required and should be 3 to 50 characters");
            RuleFor(x => x.LastName).NotNull().NotEmpty().Length(3, 50).WithMessage("Lastname is required and should be 3 to 50 characters");
            RuleFor(x => x.PolicyReferenceNumber).NotNull().NotEmpty().Must(IsPolicyNumberValid).WithMessage("Policy Reference Number is required and should be in format AB-123456");
            RuleFor(x => x.DateOfBirth).Must(Is18Years).WithMessage("Policy holder should be atleast 18 years").When(x => x.DateOfBirth != null);
            RuleFor(x => x.Email).Must(IsEmailValid).WithMessage("Email is not valid").When(x=>x.Email != string.Empty);
        }

        private bool Is18Years(DateTime? dateOfBirth)
        {
           DateTime temp = dateOfBirth.Value;
           return  (temp.AddYears(18) < DateTime.Now);
        }

        private bool IsEmailValid(string email)
        {
            string emailRegEx = @"^([A-Za-z0-9]){4,}@([A-Za-z0-9]){2,}\.com|\.co\.uk$";

            return Regex.IsMatch(email, emailRegEx);
        }

        private bool IsPolicyNumberValid(string polcyNumber)
        {
            string policyRegEx = @"^([A-Z]){2}-[1-9]{6}$";
            return Regex.IsMatch(polcyNumber, policyRegEx);
        }
    }
}
