using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleWareAssessment.Data;

namespace TeleWare.Inferastructure
{
    public static class StartupExtensions
    {
        public static void UseDatabaseInitializer(this IApplicationBuilder app)
        {
            using (var Scope = app.ApplicationServices.CreateScope())
            {
                var dbContext = Scope.ServiceProvider.GetRequiredService<TeleWareContext>();
                DatabaseInitializer.Initialize(dbContext);
            }
        }
    }
}
