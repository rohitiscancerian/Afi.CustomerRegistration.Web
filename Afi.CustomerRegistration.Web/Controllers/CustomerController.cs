using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Afi.CustomerRegistration.Web.Models;

namespace Afi.CustomerRegistration.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediatr;

        public CustomerController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpPost]
        public void Post([FromBody] CreateCustomerRequest request)
        {

        }
    }
}
