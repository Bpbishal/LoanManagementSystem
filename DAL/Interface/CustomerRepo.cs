using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public class CustomerRepo : IRepo2<Customer, int>
    {
        private readonly LMSContext db = new LMSContext();

        public void Add(Customer obj) => db.Customers.Add(obj);

        public void Delete(int id)
        {
            var c = db.Customers.Find(id);
            if (c != null) db.Customers.Remove(c);
        }

        public IEnumerable<Customer> GetAll() => db.Customers.ToList();

        public Customer GetById(int id) => db.Customers.Find(id);

        public void Update(Customer obj)
        {
            var existing = db.Customers.Find(obj.Id);
            if (existing != null)
                db.Entry(existing).CurrentValues.SetValues(obj);
        }

        public void Save() => db.SaveChanges();
    }
}
