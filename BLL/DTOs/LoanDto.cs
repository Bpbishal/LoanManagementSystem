using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class LoanDto
    {
        public int Id { get; set; }
        public string LoanNumber { get; set; }
        public decimal Amount { get; set; }
        public decimal InterestRate { get; set; }
        public DateTime StartDate { get; set; }
        public int TermMonths { get; set; }
        public string Status { get; set; }
        public List<PaymentDto> Payments { get; set; }
    }
}
