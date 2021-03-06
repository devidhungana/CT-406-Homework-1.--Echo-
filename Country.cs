﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HW1_MiniWeb.Persistence.Model
{
    public class Country : Controller
    {
        public object CountryCode { get; internal set; }
        public object CountryName { get; internal set; }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}
