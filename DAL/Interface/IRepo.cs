using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IRepo
    {
        IEnumerable<Loan> GetAll();
        Loan GetById(int id);
        void Add(Loan loan);
        void Update(Loan loan);
        void Delete(int id);
        void Save();
        IEnumerable<Loan> SearchLoans(string status, decimal? minAmount, decimal? maxAmount, 
                                       decimal? minInterest, decimal? maxInterest);

    }
}
