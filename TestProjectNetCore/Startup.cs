using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TestProjectNetCore.Repository;

namespace TestProjectNetCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;
            services.AddDbContext<TestDbContext>(options => options.UseSqlServer(connectionString, opts => opts.MigrationsAssembly(migrationsAssembly)));
            services.AddTransient<ICustomerRepository, CustomerRepository>();

            services.AddMvc();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            StaticFileOptions staticFileOptions = new StaticFileOptions
            {
                OnPrepareResponse = context =>
                {
                    context.Context.Response.Headers.Remove("Content-Length");
                },
            };


            var options = new RewriteOptions()
                     .AddRewrite(@"^ui/(.*[(js\.map)])$", @"$1", skipRemainingRules: true)
                     .AddRewrite(@"^ui/(.*[(bundle\.js)])$", @"$1", skipRemainingRules: true)
                     .AddRewrite(@"^ui/(.*[(config\.json)])$", @"$1", skipRemainingRules: true)
                     .AddRewrite(@"^ui(.*)", @"index.html", skipRemainingRules: true);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var defaultFileOptions = new DefaultFilesOptions();
            app.UseCors(builder => builder
             .AllowAnyOrigin()
             .AllowAnyHeader()
             .AllowAnyMethod());
            app.UseRewriter(options);
            app.UseDefaultFiles(defaultFileOptions);
            app.UseStaticFiles(staticFileOptions);

            app.UseMvc();
        }
    }
}
