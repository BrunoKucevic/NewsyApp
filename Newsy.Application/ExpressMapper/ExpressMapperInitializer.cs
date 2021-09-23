using Newsy.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Newsy.Application.ExpressMapper
{
    public static class ExpressMapperInitializer
    {
        public static void Initialize()
        {
            //call RegisterMappings on all classes implementing IMapperRegistrator
            Assembly
                .GetAssembly(typeof(IMapperRegistrator))
                .GetTypes()
                .Where(t => t.GetInterfaces().Contains(typeof(IMapperRegistrator))
                   && !t.IsInterface)
                .ToList()
                .ForEach(type =>
                {
                    IMapperRegistrator mapper = (IMapperRegistrator)Activator.CreateInstance(type);
                    mapper.RegisterMappings();
                });
        }
    }
}

