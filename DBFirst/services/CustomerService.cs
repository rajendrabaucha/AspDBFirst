using DBFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBFirst.services
{
    public interface CustomerService
    {
        void InsertCustomer(Customer customer); //c

        IEnumerable<Customer> getCustomers(); // R

        Customer getCustomerId(int id); // R

        void updateCustomer(Customer customer); //U

        void deleteCustomer(int id); //D

    }
}