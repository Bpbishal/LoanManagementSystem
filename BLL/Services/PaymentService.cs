using AutoMapper;
using BLL.DTOs;
using DAL.EF;
using DAL.Interface;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public static class PaymentService
    {
        private static readonly IPaymentRepository _paymentRepo = DataAccessFactory.PaymentDataAccess();
        private static readonly IMapper _mapper;

        static PaymentService()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Payment, PaymentDto>().ReverseMap();
            });
            _mapper = config.CreateMapper();
        }

        public static IEnumerable<PaymentDto> GetAll()
        {
            var payments = _paymentRepo.GetAll();
            return _mapper.Map<IEnumerable<PaymentDto>>(payments);
        }

        public static IEnumerable<PaymentDto> GetByLoanId(int loanId)
        {
            var payments = _paymentRepo.GetPaymentsByLoanId(loanId);
            return _mapper.Map<IEnumerable<PaymentDto>>(payments);
        }

        public static void Create(PaymentDto dto)
        {
            var payment = _mapper.Map<Payment>(dto);
            _paymentRepo.Add(payment);
            _paymentRepo.Save();
        }
    }
}
