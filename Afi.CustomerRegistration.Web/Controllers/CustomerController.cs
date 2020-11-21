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
        /// <summary>
        /// TODO:RK MediatR is a lightweight library for decoupling handling of request from controllers
        /// </summary>
        private readonly IMediator _mediatr;

        public CustomerController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCustomerRequest request)
        {
            var response = await _mediatr.Send(request);
            return Ok(response);
        }

        [HttpGet]
        public IActionResult Get()
        {   
            return Ok("Hello Customer");
        }
    }
}
