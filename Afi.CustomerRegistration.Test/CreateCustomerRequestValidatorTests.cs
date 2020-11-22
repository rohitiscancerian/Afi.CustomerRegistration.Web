using Afi.CustomerRegistration.Data;
using Afi.CustomerRegistration.Web.Models;
using Afi.CustomerRegistration.Web.Validators;
using Afi.CustomerRegistration.Web.RequestHandler;
using FluentAssertions;
using FluentValidation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Afi.CustomerRegistration.Test
{
    [TestClass]
    public class CreateCustomerRequestValidatorTests
    {  
        [TestMethod]
        public void Validate_CreateCustomerRequest_WithRequiredFields_Successfully()
        {
            //Arrange
            var sut = new CreateCustomerRequestValidator();
            var createCustomerRequest = Utility.GetCreateCustomerRequest(withEmailAndDoB:false);

            //Act and Assert
            sut.Validate(createCustomerRequest).IsValid.Should().BeTrue();
        }

        [TestMethod]
        public void Validate_CreateCustomerRequest_WithAllFields_Successfully()
        {
            //Arrange
            var sut = new CreateCustomerRequestValidator();
            var createCustomerRequest = Utility.GetCreateCustomerRequest(withEmailAndDoB: true);

            //Act and Assert
            sut.Validate(createCustomerRequest).IsValid.Should().BeTrue();
        }

        [TestMethod]
        public void Validate_CreateCustomerRequest_WithIncorrectPolicyNumberFormat_Successfully()
        {
            //Arrange
            var sut = new CreateCustomerRequestValidator();
            var createCustomerRequest = Utility.GetCreateCustomerRequest(withIncorrectPolicyRefFormat: true);

            //Act and Assert
            sut.Validate(createCustomerRequest).IsValid.Should().BeFalse();

        }

        [TestMethod]
        public void Validate_CreateCustomerRequest_WithIncorrectDoB_Successfully()
        {
            //Arrange
            var sut = new CreateCustomerRequestValidator();
            var createCustomerRequest = Utility.GetCreateCustomerRequest(withDoBLessThan18Years: true);

            //Act and Assert
            sut.Validate(createCustomerRequest).IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Validate_CreateCustomerRequest_WithIncorrectEmailFormat_Successfully()
        {
            //Arrange
            var sut = new CreateCustomerRequestValidator();
            var createCustomerRequest = Utility.GetCreateCustomerRequestWithIncorrrectEmailFormat();

            //Act and Assert
            sut.Validate(createCustomerRequest).IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Validate_CreateCustomerRequest_WithAllFieldsBlank_Successfully()
        {
            //Arrange
            var sut = new CreateCustomerRequestValidator();
            var createCustomerRequest = Utility.GetCreateCustomerRequestWithAllFieldsBlank();

            //Act and Assert
            sut.Validate(createCustomerRequest).IsValid.Should().BeFalse();
        }

    }
}

