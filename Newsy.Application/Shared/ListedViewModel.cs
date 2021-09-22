using Newsy.Application.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Newsy.Application
{
    public class ListedViewModel<T> : IListedViewModel
    {
        public ListedViewModel()
        {
            Data = new List<T>();
        }

        public List<T> Data { get; set; }
    }
}
