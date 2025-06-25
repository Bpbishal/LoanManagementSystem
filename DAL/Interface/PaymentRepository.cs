using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public class PaymentRepository:IPaymentRepository
    {
        private readonly LMSContext _context = new LMSContext();

        public IEnumerable<Payment> GetAll()
        {
            return _context.Payments.ToList();
        }

        public Payment GetById(int id)
        {
            return _context.Payments.Find(id);
        }

        public void Add(Payment payment)
        {
            _context.Payments.Add(payment);
        }

        public void Update(Payment payment)
        {
            _context.Entry(payment).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(int id)
        {
            var payment = _context.Payments.Find(id);
            if (payment != null)
                _context.Payments.Remove(payment);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
        public IEnumerable<Payment> GetPaymentsByLoanId(int loanId)
        {
            return _context.Payments.Where(p => p.LoanId == loanId).ToList();
        }

    }
}
