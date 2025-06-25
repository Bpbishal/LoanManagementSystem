using DAL.EF;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class DataAccessFactory
    {
        public static IRepo LoanDataAccess()
        {
            return new LoanRepo();
        }

        public static IPaymentRepository PaymentDataAccess()
        {
            return new PaymentRepository();
        }
        public static IRepo2<Customer, int> CustomerDataAccess()
        {
            return new CustomerRepo();
        }

    }
}
