using ExpressMapper;
using Newsy.Domain.Entities;
using Newsy.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Newsy.Domain.ViewModels.Users
{
    public class AllUsersViewModelMapper: IMapperRegistrator
    {
        public void RegisterMappings()
        {
            Mapper.Register<AppUser, AllUsersViewModel>()
                .Member(dest => dest.Id, src => src.Id)
                .Member(dest => dest.FirstName, src => src.FirstName)
                .Member(dest => dest.Username, src => src.UserName)
                .Member(dest => dest.Email, src => src.Email)
                .Member(dest => dest.PhoneNumber, src => src.PhoneNumber)
                .Function(dest => dest.RoleNames, src =>
                {
                    return src.UserRoles.Select(role => role.Role.Name).ToList();
                });
        }
    }
}
