using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IPaymentRepository
    {
        IEnumerable<Payment> GetAll();
        Payment GetById(int id);
        void Add(Payment payment);
        void Update(Payment payment);
        void Delete(int id);
        IEnumerable<Payment> GetPaymentsByLoanId(int loanId);
        void Save();
    }
}
