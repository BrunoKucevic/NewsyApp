using ExpressMapper;
using Newsy.Domain.Entities;
using Newsy.Domain.Interfaces;
using Newsy.Domain.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Newsy.Domain.ViewModels.Roles
{
    public class RolesViewModelMapper : IMapperRegistrator
    {
        public void RegisterMappings()
        {
            Mapper.Register<Role, RolesViewModel>();
            Mapper.Register<RoleClaim, UserRoleClaimsViewModel>();
        }
    }
}
