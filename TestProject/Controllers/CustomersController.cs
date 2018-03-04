using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using TestProject.Models;
using TestProject.Repository;

namespace TestProject.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    public class CustomersController : ApiController
    {
        // private TestProjectContext db = new TestProjectContext();
        private ICustomerRepository iCustomerRepository;

        public CustomersController(ICustomerRepository iCustomerRepository)
        {
            this.iCustomerRepository = iCustomerRepository;
        }
        // GET: api/Customers
        public IQueryable<Customer> GetCustomers()
        {
            return iCustomerRepository.GetCustomers();
        }

        // GET: api/Customers/5
        [ResponseType(typeof(Customer))]
        public async Task<IHttpActionResult> GetCustomer(int id)
        {
            Customer customer = await iCustomerRepository.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        // PUT: api/Customers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCustomer(int id, Customer customer)
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

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Customers
        [ResponseType(typeof(Customer))]
        public async Task<IHttpActionResult> PostCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            await iCustomerRepository.InsertCustomers(customer);

            return CreatedAtRoute("DefaultApi", new { id = customer.Id }, customer);
        }

        // DELETE: api/Customers/5
        [ResponseType(typeof(Customer))]
        public async Task<IHttpActionResult> DeleteCustomer(int id)
        {
            var updated=await iCustomerRepository.DeleteCustomers(id);
            if (updated < 0)
            {
                return Ok(400);
            }
            return Ok(200);
        }

      
    }
}