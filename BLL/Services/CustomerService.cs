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
    public static class CustomerService
    {
        private static readonly IRepo2<Customer, int> _repo = DataAccessFactory.CustomerDataAccess();
        private static readonly IMapper _mapper;

        static CustomerService()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            _mapper = config.CreateMapper();
        }

        public static IEnumerable<CustomerDto> GetAll()
        {
            return _mapper.Map<IEnumerable<CustomerDto>>(_repo.GetAll());
        }

        public static void Create(CustomerDto dto)
        {
            var c = _mapper.Map<Customer>(dto);
            _repo.Add(c);
            _repo.Save();
        }
    }

}
