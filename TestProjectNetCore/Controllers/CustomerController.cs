using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestProjectNetCore.Model;
using TestProjectNetCore.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestProjectNetCore.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        // GET: api/<controller>
        private ICustomerRepository iCustomerRepository;

        public CustomerController(ICustomerRepository iCustomerRepository)
        {
            this.iCustomerRepository = iCustomerRepository;
        }

        [HttpGet]
        public IQueryable<Customer> GetCustomers()
        {
            return iCustomerRepository.GetCustomers();
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            Customer customer = await iCustomerRepository.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        // PUT: api/Customers/5
        public async Task<IActionResult> PutCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customer.Id)
            {
                return BadRequest();
            }

            await iCustomerRepository.UpadateCustomer(customer);

            return Ok();
        }

        // POST: api/Customers
        public async Task<IActionResult> PostCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            await iCustomerRepository.InsertCustomers(customer);

            return CreatedAtRoute("DefaultApi", new { id = customer.Id }, customer);
        }

        // DELETE: api/Customers/5
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var updated = await iCustomerRepository.DeleteCustomers(id);
            if (updated < 0)
            {
                return Ok(400);
            }
            return Ok(200);
        }
        
    }
}
