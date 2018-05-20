using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using JFESM.Model;
using JFESM.Persistence;
using System.Collections.Generic;
using System;

namespace JFESM.Web
{
    public partial class Startup
    {
        private static void SeedDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<JFESMContext>();
            }
        }
    }
}