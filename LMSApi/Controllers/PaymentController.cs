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
    public class PaymentController : ApiController
    {
        [HttpGet]
        [Route("api/payments/all")]
        public HttpResponseMessage Get()
        {
            var data = PaymentService.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("api/payments/byloan/{loanId}")]
        public HttpResponseMessage GetByLoanId(int loanId)
        {
            var data = PaymentService.GetByLoanId(loanId);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpPost]
        [Route("api/payments/create")]
        public HttpResponseMessage Create(PaymentDto dto)
        {
            PaymentService.Create(dto);
            return Request.CreateResponse(HttpStatusCode.OK, "Payment added successfully");
        }
    }
}
