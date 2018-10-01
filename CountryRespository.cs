using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HW1_MiniWeb.Persistence.Model;
using System.IO;
using Newtonsoft.Json;
using CoreBook.HW1_MiniWeb.Persistence.Abstractions;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HW1_MiniWeb
{
    public class CountryRespository : ICountryRepository

    {
        private static IList<Country> _Countries;

        public IQueryable<Country> All()
        {
            EnsureCountriesAreLoaded();
            return _Countries.AsQueryable();
        }

        public Country Find(string code)
        {
            return (from c in All()
                    where c.CountryCode.Equals(code, StringComparison.CurrentCultureIgnoreCase)
                    select c).FirstOrDefault();

        }

        public IQueryable<Country> AllBy(string filter)
        {
            var normalized = filter.ToLower();
            return String.IsNullOrEmpty(filter)
                ? All()
                : (All().Where(c => c.CountryName.ToLower().StartWith(normalized)));
        }
        #region PRIVATE
        private static void EnsureCountriesAreLoaded()
        {
            if (_Countries == null)
                _Countries = LoadCountriesFromStream();
        }
        private static IList<Country> LoadCountriesFromStream()
        {
            var json = File.ReadAllText("Countries.json");
            var countries = JsonConvert.DeserializeObject<Country[]>(json);
            return countries.OrderBy(c => c.CountryName).ToList();
        }
        #endregion
    }
}

