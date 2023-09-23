using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TeleWare.Core.Interfaces;
using TeleWareAssessment.Data;

namespace TeleWare.Inferastructure
{
    public static class PersistenceContainer
    {

        public static WebApplicationBuilder AddPersistenceServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<TeleWareContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("constring"));
            });
          

            builder.WebHost.UseUrls("https://localhost:7256");

           
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<IAddressReposiory, AddressReposiory>();
            return builder;
        }



    }
}