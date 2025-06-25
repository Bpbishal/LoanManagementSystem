using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public class LoanRepo:IRepo
    {
        private readonly LMSContext _context = new LMSContext();

        public IEnumerable<Loan> GetAll() => _context.Loans.ToList();

        public Loan GetById(int id) => _context.Loans.Find(id);

        public void Add(Loan loan)
        {
            _context.Loans.Add(loan);
        }

        public void Update(Loan loan)
        {
            _context.Entry(loan).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(int id)
        {
            var loan = GetById(id);
            if (loan != null)
                _context.Loans.Remove(loan);
        }

        public void Save() => _context.SaveChanges();
        public IEnumerable<Loan> SearchLoans(string status, decimal? minAmount, decimal? 
                                            maxAmount, decimal? minInterest, decimal? maxInterest)
        {
            var query = _context.Loans.AsQueryable();

            if (!string.IsNullOrEmpty(status))
                query = query.Where(l => l.Status.ToLower() == status.ToLower());

            if (minAmount.HasValue)
                query = query.Where(l => l.Amount >= minAmount.Value);

            if (maxAmount.HasValue)
                query = query.Where(l => l.Amount <= maxAmount.Value);

            if (minInterest.HasValue)
                query = query.Where(l => l.InterestRate >= minInterest.Value);

            if (maxInterest.HasValue)
                query = query.Where(l => l.InterestRate <= maxInterest.Value);

            return query.ToList();
        }

    }
}
