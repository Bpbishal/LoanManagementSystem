using BLL.DTOs;
using BLL.Services;
using DAL.EF;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LMSApi.Controllers
{
    public class LoanController : ApiController
    {
        private readonly IService _loanService;

        [HttpGet]
        [Route("api/loans/all")]
        public HttpResponseMessage GetAll()
        {
            var data = LoanService.GetAllLoans();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("api/loans/search")]
        public HttpResponseMessage Search(
            string status = null,
            decimal? minAmount = null,
            decimal? maxAmount = null,
            decimal? minInterest = null,
            decimal? maxInterest = null)
        {
            var data = LoanService.SearchLoans(status, minAmount, maxAmount, minInterest, maxInterest);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("api/loans/{id}")]
        public HttpResponseMessage GetById(int id)
        {
            var loan = LoanService.GetLoanById(id);
            if (loan == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, "Loan not found");

            return Request.CreateResponse(HttpStatusCode.OK, loan);
        }

        [HttpPost]
        [Route("api/loans/create")]
        public HttpResponseMessage Create(LoanDto loanDto)
        {
            LoanService.CreateLoan(loanDto);
            return Request.CreateResponse(HttpStatusCode.OK, "Loan created successfully");
        }

        [HttpPut]
        [Route("api/loans/update")]
        public HttpResponseMessage Update(LoanDto loanDto)
        {
            LoanService.UpdateLoan(loanDto);
            return Request.CreateResponse(HttpStatusCode.OK, "Loan updated successfully");
        }

        [HttpDelete]
        [Route("api/loans/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            LoanService.DeleteLoan(id);
            return Request.CreateResponse(HttpStatusCode.OK, "Loan deleted successfully");
        }
        [HttpGet]
        [Route("api/loans/summary")]
        public HttpResponseMessage GetSummary()
        {
            var summary = LoanService.GetLoanSummary();
            return Request.CreateResponse(HttpStatusCode.OK, summary);
        }
        [HttpGet]
        [Route("api/loans/paymentstatus/{id}")]
        public HttpResponseMessage GetPaymentStatus(int id)
        {
            var status = LoanService.GetLoanPaymentStatus(id);
            if (status == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, "Loan not found");

            return Request.CreateResponse(HttpStatusCode.OK, status);
        }
        [HttpGet]
        [Route("api/loans/report/statusbreakdown")]
        public HttpResponseMessage GetLoanStatusReport()
        {
            var report = LoanService.GetLoanStatusReport();
            return Request.CreateResponse(HttpStatusCode.OK, report);
        }


    }
}
