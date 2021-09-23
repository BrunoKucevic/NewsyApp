using System;
using System.Collections.Generic;
using System.Text;

namespace Newsy.Application
{
    public static class AppInit
    {
        public static void Initialize()
        {
            ExpressMapper.ExpressMapperInitializer.Initialize();
        }
    }
}
