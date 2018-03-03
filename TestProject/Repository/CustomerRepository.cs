using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TestProject.Models;

namespace TestProject.Repository
{
    public class CustomerRepository : ICustomerRepository, IDisposable
    {
        private TestProjectContext context;

        public CustomerRepository(TestProjectContext context)
        {
            this.context = context;
        }
        public async Task<int> DeleteCustomers(int customerId)
        {
            Customer customer = await context.Customers.FindAsync(customerId);
           

            context.Customers.Remove(customer);
            return await context.SaveChangesAsync();

        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (context != null)
                {
                    context.Dispose();
                    context = null;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<Customer> GetCustomerById(int customerId)
        {
            Customer customer = await context.Customers.FindAsync(customerId);

            return customer;
        }

        public IQueryable<Customer> GetCustomers()
        {
            return context.Customers;
        }

        public async Task<int> InsertCustomers(Customer customer)
        {
            context.Customers.Add(customer);
            return await context.SaveChangesAsync();
        }

        public async Task<int> UpadateCustomer(Customer customer)
        {
            
            context.Entry(customer).State = EntityState.Modified;

            try
            {
                return await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        
    }
}