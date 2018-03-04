using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProjectNetCore.Model;

namespace TestProjectNetCore.Repository
{
    public class TestDbContext : DbContext
    {
        public TestDbContext(DbContextOptions<TestDbContext> options) : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }

    }
}
