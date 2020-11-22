using Afi.CustomerRegistration.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Afi.CustomerRegistration.Web.Models;
using System;

namespace Afi.CustomerRegistration.Test
{
    public static class Utility
    {
        public static DbContextOptions<CustomerRegistrationContext> CreateNewContextOptions()
        {
            // Create a fresh service provider, and therefore a fresh
            // InMemory database instance.
            var serviceProvider = new ServiceCollection().AddEntityFrameworkInMemoryDatabase().BuildServiceProvider();

            // Create a new options instance telling the context to use an
            // InMemory database and the new service provider.
            var builder = new DbContextOptionsBuilder<CustomerRegistrationContext>();
            builder.UseInMemoryDatabase(databaseName: "CustomerRegistration")
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }

        public static CreateCustomerRequest GetCreateCustomerRequest(bool withEmailAndDoB = false,bool withIncorrectPolicyRefFormat = false)
        {
            return new CreateCustomerRequest() { FirstName = "roy", 
                                                 LastName = "dast", 
                                                 PolicyReferenceNumber = withIncorrectPolicyRefFormat? "X-123" :"AS-234576",
                                                 DateOfBirth = withEmailAndDoB? Get18YearsBackDate() : (DateTime?)null, 
                                                 Email = withEmailAndDoB?"roy@dast.co.uk":string.Empty   };
        }
        public static CreateCustomerRequest GetCreateCustomerRequest(bool withDoBLessThan18Years = false)
        {
            // TODO:RK I have repeated violating DRY principles. Need to refactor this method
            return new CreateCustomerRequest()
            {
                FirstName = "roy",
                LastName = "dast",
                PolicyReferenceNumber = "AS-234576",
                DateOfBirth = withDoBLessThan18Years ? Get17YearsBackDate() : Get18YearsBackDate(),
                Email = "roy@dast.co.uk"
            };
        }

        public static CreateCustomerRequest GetCreateCustomerRequestWithIncorrrectEmailFormat()
        {
            // TODO:RK I have repeated violating DRY principles. Need to refactor this method
            return new CreateCustomerRequest()
            {
                FirstName = "roy",
                LastName = "dast",
                PolicyReferenceNumber = "AS-234566",
                DateOfBirth =  Get18YearsBackDate(),
                Email = "r@s.com"
            };
        }
        public static CreateCustomerRequest GetCreateCustomerRequestWithAllFieldsBlank()
        {
            return new CreateCustomerRequest()
            {
                FirstName = "",
                LastName = "",
                PolicyReferenceNumber =  "",
                DateOfBirth = null,
                Email = ""
            };
        }

        /// <summary>
        /// TODO:RK I would create more test data to cover 
        /// date of birth boundary conditions with month start 
        /// and end dates with both leap and non-lep year so totally 24 different dates
        /// </summary>
        /// <returns></returns>
        public static DateTime Get18YearsBackDate()
        {
            return DateTime.Now.AddYears(-18);
        }
        public static DateTime Get17YearsBackDate()
        {
            return DateTime.Now.AddYears(-17);
        }
    }
}
