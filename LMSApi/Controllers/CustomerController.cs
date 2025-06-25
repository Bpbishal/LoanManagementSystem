using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LMSApi.Controllers
{
    public class CustomerController : ApiController
    {
        [HttpGet]
        [Route("api/customers/all")]
        public HttpResponseMessage Get()
        {
            var data = CustomerService.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpPost]
        [Route("api/customers/create")]
        public HttpResponseMessage Create(CustomerDto dto)
        {
            CustomerService.Create(dto);
            return Request.CreateResponse(HttpStatusCode.OK, "Customer created");
        }
    }
}
