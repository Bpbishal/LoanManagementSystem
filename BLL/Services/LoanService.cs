using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public static class LoanService
    {
        private static readonly IRepo _loanRepository = DataAccessFactory.LoanDataAccess();

        private static readonly IMapper _mapper;

        static LoanService()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = config.CreateMapper();
        }

        public static IEnumerable<LoanDto> GetAllLoans()
        {
            var loans = _loanRepository.GetAll();
            return _mapper.Map<IEnumerable<LoanDto>>(loans);
        }

        public static LoanDto GetLoanById(int id)
        {
            var loan = _loanRepository.GetById(id);
            return _mapper.Map<LoanDto>(loan);
        }

        public static void CreateLoan(LoanDto loanDto)
        {
            var loan = _mapper.Map<Loan>(loanDto);
            _loanRepository.Add(loan);
            _loanRepository.Save();
        }

        public static void UpdateLoan(LoanDto loanDto)
        {
            var loan = _mapper.Map<Loan>(loanDto);
            _loanRepository.Update(loan);
            _loanRepository.Save();
        }

        public static void DeleteLoan(int id)
        {
            _loanRepository.Delete(id);
            _loanRepository.Save();
        }

        public static IEnumerable<LoanDto> SearchLoans(string status, decimal? minAmount, decimal?
                                                maxAmount, decimal? minInterest, decimal? maxInterest)
        {
            var loans = _loanRepository.SearchLoans(status, minAmount, maxAmount, minInterest,
                                                    maxInterest);
            return _mapper.Map<IEnumerable<LoanDto>>(loans);
        }
        public static object GetLoanSummary()
        {
            var loans = _loanRepository.GetAll();

            var totalAmount = loans.Sum(l => l.Amount);
            var activeAmount = loans.Where(l => l.Status.ToLower() == "active").Sum(l => l.Amount);
            var completedAmount = loans.Where(l => l.Status.ToLower() == "completed").Sum(l => l.Amount);

            return new
            {
                TotalLoanAmount = totalAmount,
                ActiveLoanAmount = activeAmount,
                CompletedLoanAmount = completedAmount
            };
        }
        public static object GetLoanPaymentStatus(int loanId)
        {
            var loan = DataAccessFactory.LoanDataAccess().GetById(loanId);
            if (loan == null) return null;

            var payments = DataAccessFactory.PaymentDataAccess().GetPaymentsByLoanId(loanId);
            decimal totalPaid = payments.Sum(p => p.Amount);
            decimal remaining = loan.Amount - totalPaid;
            decimal percentPaid = loan.Amount == 0 ? 0 : (totalPaid / loan.Amount) * 100;

            return new
            {
                LoanId = loan.Id,
                LoanNumber = loan.LoanNumber,
                TotalAmount = loan.Amount,
                TotalPaid = totalPaid,
                RemainingAmount = remaining,
                PercentPaid = Math.Round(percentPaid, 2)
            };
        }
        public static object GetLoanStatusReport()
        {
            var loans = DataAccessFactory.LoanDataAccess().GetAll();

            var statusReport = loans
                .GroupBy(l => l.Status)
                .Select(g => new
                {
                    Status = g.Key,
                    Count = g.Count(),
                    TotalAmount = g.Sum(l => l.Amount)
                })
                .ToList();

            return statusReport;
        }



    }


}

