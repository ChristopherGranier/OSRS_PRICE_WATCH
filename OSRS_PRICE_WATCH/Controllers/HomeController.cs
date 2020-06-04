using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OSRS_PRICE_WATCH.Models;
using ConsoleApp7;


namespace OSRS_PRICE_WATCH.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var url = "https://api.osrsbox.com/items?where={ \"name\": \"Abyssal whip\", \"duplicate\": false }";
            _Items test1 = new _Items();
            Items test = new Items();
            test1 = Test.Download_serialized_json_data(url);
            test.Name = test1.name;
            test.Price = test1.cost;

            return View(test);
        }
    }
}