using System;
using System.Collections.Generic;
using System.Text;

namespace Newsy.Application.Shared.Interfaces
{
    public interface ICurrentUserAccessor
    {
        string GetUsername();

        string GetUserFullName();
        Guid GetUserId();
    }
}
