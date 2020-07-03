using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OSRS_PRICE_WATCH.Models;
using OsrsBoxImplementation;

namespace OSRS_PRICE_WATCH.Controllers
{
    public class HomeController : Controller
    {

        public ViewResult About() => View();
        public ViewResult Favorites() => View();

        public ActionResult Stocks()
        {
            return View();
        }

        //TODO: Make this action return an array of _Items 
        //      for the featured items on the home page
        public ActionResult Index()
        {
            var url = "https://api.osrsbox.com/items?where={ \"name\": \"Abyssal whip\", \"duplicate\": false }";
            _Items defaultItem = new _Items();
            defaultItem = (DownloadedItem.Download_serialized_json_data(url));
            return View(defaultItem);
        }

        [HttpPost]
        public ActionResult Index(Items item)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Search", item);
            }
            else
            {
                return View();

            }



        }


        public IActionResult Search(Items item)
        {
            var url = "https://api.osrsbox.com/items?where={ \"name\": \"" + item.Name + "\", \"duplicate\": false }";
            _Items searchedItems = new _Items();
            searchedItems = DownloadedItem.Download_serialized_json_data(url);
            return View(searchedItems);
        }
    }
}