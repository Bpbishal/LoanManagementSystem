using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class Loan
    {
        public int Id { get; set; }
        public string LoanNumber { get; set; }
        public decimal Amount { get; set; }
        public decimal InterestRate { get; set; }
        public DateTime StartDate { get; set; }
        public int TermMonths { get; set; }
        public string Status { get; set; } // Active, Closed, Defaulted
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
