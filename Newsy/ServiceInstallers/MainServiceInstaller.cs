using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newsy.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Newsy.ServiceInstallers
{
    public static class MainServiceInstaller
    {
        public static void InstallAllServices (this IServiceCollection services, IConfiguration configuration)
        {
            var serviceInstallers = typeof(Startup).Assembly.ExportedTypes
                .Where(x => typeof(IServiceInstaller).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .Select(Activator.CreateInstance).Cast<IServiceInstaller>().ToList();

            serviceInstallers.ForEach(i => i.InstallServices(services, configuration));
        }

    }
}
