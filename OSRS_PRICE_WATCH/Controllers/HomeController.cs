using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OSRS_PRICE_WATCH.Models;

namespace OSRS_PRICE_WATCH.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            Items test = new Items();
            test.ItemID = "123r3";
            return View(test);
        }
    }
}