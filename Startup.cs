using GraphiQl;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetflixGraphQL.Database.Implementation;
using NetflixGraphQL.Database.Interfaces;
using NetflixGraphQL.Helpers;
using NetflixGraphQL.Queries;
using NetflixGraphQL.Schema;
using NetflixGraphQL.Types;

namespace NetflixGraphQL
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //services.AddResponseCompression(options =>
            //{
            //    options.Providers.Add(new CustomCompressionProvider());
            //});

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddTransient<IAllShows, AllShows>();
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<ShowQueries>();
            services.AddSingleton<ShowsType>();

            var sp = services.BuildServiceProvider();
            services.AddSingleton<ISchema>(new ShowsSchema(new FuncDependencyResolver(type => sp.GetService(type))));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            app.UseGraphiQl();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            //app.UseResponseCompression();
            app.UseMvcWithDefaultRoute();
            app.UseMvc();
        }
    }
}
