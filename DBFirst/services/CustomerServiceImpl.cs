using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using DBFirst.Models;

namespace DBFirst.services
{
    public class CustomerServiceImpl : CustomerService
    {

        private DBFirstTestEntities dbContext;
        public CustomerServiceImpl(DBFirstTestEntities objectDbContext)
        {
            this.dbContext = objectDbContext;
        }

        public void deleteCustomer(int id)
        {
            Customer customer = dbContext.Customers.Find(id);
            dbContext.Customers.Remove(customer);
            dbContext.SaveChanges();
        }

        public Customer getCustomerId(int id)
        {
            return dbContext.Customers.Find(id);
        }

        public IEnumerable<Customer> getCustomers()
        {
            return dbContext.Customers.ToList();
        }

        public void InsertCustomer(Customer customer)
        {
            dbContext.Customers.Add(customer);

            dbContext.SaveChanges();
        }


        public void updateCustomer(Customer customer)
        {
            dbContext.Entry(customer).State = EntityState.Modified;

            dbContext.SaveChanges();
        }
    }
}