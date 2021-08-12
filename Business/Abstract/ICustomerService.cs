using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        List<Customer> GetAll();
        Customer GetByCustomerId(int id);
        Customer GetByCustomerName(string name);

        void Insert(Customer customer);
        void Delete(Customer customer);
        void Update(Customer customer);
    }
}
