using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DAL.EF;

namespace BLL.DTOs
{
   public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            // Entity to DTO
            CreateMap<Loan, LoanDto>().ReverseMap();
            CreateMap<Payment, PaymentDto>().ReverseMap();
            CreateMap<Customer, CustomerDto>().ReverseMap();

            // DTO to Entity (Optional, useful for Create/Update)
            CreateMap<LoanDto, Loan>();
            CreateMap<PaymentDto, Payment>();
        }
    }
}
