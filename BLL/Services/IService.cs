using BLL.DTOs;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IService
    {
        IEnumerable<LoanDto> GetAllLoans();
        LoanDto GetLoanById(int id);
        void CreateLoan(LoanDto loanDto);
        void UpdateLoan(LoanDto loanDto);
        void DeleteLoan(int id);

        IEnumerable<LoanDto> SearchLoans(string status, decimal? minAmount, decimal? maxAmount, 
                                        decimal? minInterest, decimal? maxInterest);

    }
}
