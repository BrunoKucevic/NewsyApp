using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Newsy.Application.Shared.Interfaces
{
    public interface IException
    {
        string GetSystemErrorMessage();
        string GetName();
        string GetType();
        HttpStatusCode StatusCode { get; }
    }
}
