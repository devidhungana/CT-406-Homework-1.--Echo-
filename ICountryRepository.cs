using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HW1_MiniWeb.Persistence.Model;

namespace CoreBook.HW1_MiniWeb.Persistence.Abstractions
{
    interface ICountryRepository
    {
        IQueryable<Country> All();
        Country Find(string code);
        IQueryable<Country> AllBy(string filter);
    }
}
