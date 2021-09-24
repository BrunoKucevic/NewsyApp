using System;
using System.Collections.Generic;
using System.Text;

namespace Newsy.Domain.ViewModels.Users
{
    public class AllUsersViewModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public List<string> RoleNames { get; set; }
    }
}
