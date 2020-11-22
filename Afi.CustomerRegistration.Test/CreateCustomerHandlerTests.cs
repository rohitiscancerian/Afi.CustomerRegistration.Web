using Afi.CustomerRegistration.Data;
using Afi.CustomerRegistration.Web.Models;
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
    public class CreateCustomerHandlerTests
    {
        
        private CustomerRegistrationContext _customerRegistrationContext;
        [TestInitialize]
        public void SetupTests()
        {
            _customerRegistrationContext = new CustomerRegistrationContext(Utility.CreateNewContextOptions());          
        }
        [TestMethod]
        public async Task Handle_CreateCustomer_WithAllMandatoryFields_Successfully()
        {
            //Arrange
            var sut = new CreateCustomerHandler(_customerRegistrationContext);
            var createCustomerRequest = Utility.GetCreateCustomerRequest(withEmailAndDoB:false);

            //Act
            await sut.Handle(createCustomerRequest, CancellationToken.None);

            //Assert
            _customerRegistrationContext.Customers.Count().Should().Be(1);
        }
        [TestMethod]
        public async Task Handle_CreateCustomer_WithAllMandatoryFields_AndEmailDoB_Successfully()
        {
            //Arrange
            var sut = new CreateCustomerHandler(_customerRegistrationContext);
            var createCustomerRequest = Utility.GetCreateCustomerRequest(withEmailAndDoB:true);

            //Act
            await sut.Handle(createCustomerRequest, CancellationToken.None);

            //Assert
            _customerRegistrationContext.Customers.Count().Should().Be(1);
        }
    }
}
