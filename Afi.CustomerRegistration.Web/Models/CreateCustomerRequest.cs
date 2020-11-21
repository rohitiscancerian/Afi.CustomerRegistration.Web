using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Afi.CustomerRegistration.Web.Models
{
    public class CreateCustomerRequest : IRequest<CreateCustomerResponse>
    {
        // Property names could be better. I followed whats on the spec.
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PolicyReferenceNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Email { get; set; }
    }
}
