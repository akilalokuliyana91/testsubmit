using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TestProject.Models;

namespace TestProject.Repository
{
    public interface ICustomerRepository:IDisposable
    {
        Task<int> InsertCustomers(Customer customer);

        IQueryable<Customer> GetCustomers();

        Task<int> UpadateCustomer(Customer customer);

        Task<int> DeleteCustomers(int customerId);

        Task<Customer> GetCustomerById(int customerId);

    }
}