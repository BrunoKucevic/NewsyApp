using Newsy.Application.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Newsy.Application.Shared.Exceptions
{
    public class UserLockedOutException : Exception, IException
    {
        private readonly string key;
        private readonly string name;

        public UserLockedOutException(string name, string key)
            : base($"User {key} locked out")
        {
            this.name = name;
            this.key = key;
        }

        public HttpStatusCode StatusCode => HttpStatusCode.NotFound;

        public string GetName()
        {
            return name;
        }

        public string GetSystemErrorMessage()
        {
            return StackTrace;
        }

        string IException.GetType()
        {
            return base.GetType().Name;
        }
    }
}
