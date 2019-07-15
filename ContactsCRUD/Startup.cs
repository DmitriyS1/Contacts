using AutoMapper;
using Contacts.DTO.Requests;
using ContactsApi.Dal.Repositories;
using ContactsApi.Dal.Repositories.Interfaces;
using ContactsApi.MappingProfiles;
using ContactsApi.Services;
using ContactsApi.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ContactsCRUD
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
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ContactMappingProfile());
            });
            services.AddSingleton(mappingConfig.CreateMapper());

            services.AddTransient<IValidator<CreateContactModel>, CreateContactModelValidator>();

            services.AddTransient<IContactsService, ContactsService>();
            services.AddTransient<IContactsRepository, ContactsRepository>();

            services.AddMvc().AddFluentValidation().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddApiVersioning(o => o.ApiVersionReader = new HeaderApiVersionReader("api-version"));

            services.AddTransient<IContactsRepository, ContactsRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
