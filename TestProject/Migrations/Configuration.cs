namespace TestProject.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TestProject.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TestProject.Repository.TestProjectContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TestProject.Repository.TestProjectContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Customers.AddOrUpdate(
              p => p.Id,
              new Customer { Id=1, CustomerAddress="46/10 LA",CustomerName = "Andrew Peters",CustomerNumber="0114785999" },
              new Customer { Id = 2, CustomerAddress = "46/10 BA", CustomerName = "James Peters", CustomerNumber = "0114745999" },
              new Customer { Id = 3, CustomerAddress = "46/10 AB", CustomerName = "Peter Grills", CustomerNumber = "0114585999" }
            );
            //
        }
    }
}
