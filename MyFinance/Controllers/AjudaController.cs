﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MyFinance.Controllers
{
    public class AjudaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}