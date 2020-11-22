using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Afi.CustomerRegistration.Web.Models;
using Afi.CustomerRegistration.Data;
using System.Threading;

namespace Afi.CustomerRegistration.Web.RequestHandler
{
    /// <summary>
    /// TODO:RK This can be refactored to put in a separate project. Write tests for the handler
    /// </summary>
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerRequest,CreateCustomerResponse>
    {
        private readonly CustomerRegistrationContext _context;
        public CreateCustomerHandler(CustomerRegistrationContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        /// <summary>
        /// Not much is happening in handle method but its meant to hold any business logic 
        /// conditions etc before saving to database
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<CreateCustomerResponse> Handle(CreateCustomerRequest request, CancellationToken cancellationToken)
        {
            var dbCustomer = MapCustomer(request);
            _context.Customers.Add(dbCustomer);
            await _context.SaveChangesAsync();

            return new CreateCustomerResponse() { CustomerId = dbCustomer.Id };
        }
        /// <summary>
        /// TODO:RK Alternatively, I could have used AutoMapper or similar tool 
        /// for mapping application layer and db models
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private Customer MapCustomer(CreateCustomerRequest request)
        {
            var customer = new Customer() { 
                                            FirstName = request.FirstName,
                                            LastName = request.LastName, 
                                            DateOfBirth = request.DateOfBirth, 
                                            Email = request.Email, 
                                            PolicyReferenceNumber = request.PolicyReferenceNumber 
                                           };
            return customer;
        }
    }
}
