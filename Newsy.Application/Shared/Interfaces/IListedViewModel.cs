using System;
using System.Collections.Generic;
using System.Text;

namespace Newsy.Application.Shared.Interfaces
{
    public interface IListedViewModel
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalRows { get; set; }
    }
}
