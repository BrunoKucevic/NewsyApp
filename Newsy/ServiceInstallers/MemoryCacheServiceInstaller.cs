using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newsy.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Newsy.ServiceInstallers
{
    public class MemoryCacheServiceInstaller : IServiceInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMemoryCache();
        }
    }
}
