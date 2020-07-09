using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OSRS_PRICE_WATCH.Models;
using OsrsBoxImplementation;
using static OsrsBoxImplementation.OsrsGe;

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

        /*
         * Default landing page
         * 
         * @variables:    tempArray, _Items[]- used to gather an ID for featured items from OsrsBox API
         *                arrFeatItems, RootobjectOsrsGe[]- used to gather GE price of items from OSRS GE API
         * 
         * 
         * 
         * @returns: RootobjectOsrsGe[] arrFeatItems, used to find GE price of items
         */
        public ViewResult Index()
        {
            var url = string.Empty;

            List<string> featItems = new List<string>()
            {
                "Abyssal whip",
                "Elder maul",
                "Twisted bow",
            };
            _Items[] tempArray = new _Items[featItems.Count()];
            for (int i = 0; i < featItems.Count(); i++)
            {
                url = "https://api.osrsbox.com/items?where={ \"name\": \"" + featItems[i] + "\", \"duplicate\": false }";
                tempArray[i] = DownloadedItem.Download_serialized_json_data(url);
            }
            RootobjectOsrsGe[] arrFeatItems = new RootobjectOsrsGe[featItems.Count()];
            for (int i = 0; i < featItems.Count(); i++)
            {
                url = "https://secure.runescape.com/m=itemdb_oldschool/api/catalogue/detail.json?item=" + tempArray[i].id;
                arrFeatItems[i] = DownloadedItemOsrsGe.Download_serialized_json_data(url);
            }

            return View(arrFeatItems);
        }

        /*
         * Validates input on the Name field
         * 
         * 
         * 
         * Redirects a user to the search view 
         */
        [HttpPost]
        public ActionResult Stocks(Items item)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Search", item);
            }
            else
            {
                ModelState.AddModelError("Empty", "Please enter an item");

                return RedirectToAction("Stocks");
            }
        }


        /*
         * Validates user input on the name field
         * 
         * @variables:  newItem, Items- used to convert the input from a RootobjectOsrsGe to
         *                              an Items class to gather the ID
         * 
         * Redirects users to the search page returning the item they entered
         */
        [HttpPost]
        public ActionResult Search(RootobjectOsrsGe searchedItem)
        {
            if (ModelState.IsValid)
            {
                Items newItem = new Items();
                newItem.Name = searchedItem.item.name;
                return RedirectToAction("Search", newItem);
            }
            else
            {

                return View("Stocks");
            }
        }
        /*
         * Formats the search to input into OSRSBox Api
         * 
         * @variables:  searchedItems, _Items- used to gather the ID from the OSRSBox api to pass to 2nd API
         *              specificItem, RootobjectOsrsGe- used to gather GE information from the OSRS GE API
         * 
         */
        public IActionResult Search(Items item)
        {
            item.Name = item.Name.ToLower();
            item.Name = char.ToUpper(item.Name[0]) + item.Name.Substring(1);
            RootobjectOsrsGe specificItem = new RootobjectOsrsGe();
            var url = "https://api.osrsbox.com/items?where={ \"name\": \"" + item.Name + "\", \"duplicate\": false }&max_results=1";
            _Items searchedItems = new _Items();
            searchedItems = DownloadedItem.Download_serialized_json_data(url);
            if (searchedItems.id != null)
            {
                
                url = "https://secure.runescape.com/m=itemdb_oldschool/api/catalogue/detail.json?item=" + searchedItems.id;
                specificItem = DownloadedItemOsrsGe.Download_serialized_json_data(url);
                return View(specificItem);
            }
            else
            {
                ModelState.AddModelError("Invalid", "Please enter a valid item name");
            
                return View("Stocks");
            }

            
        }

        //public ViewResult Test()
        //{
        //    var url = string.Empty;
        //    string baseurl = "https://secure.runescape.com/m=itemdb_oldschool/api/catalogue/detail.json?item=";
        //    List<string> featItems = new List<string>()
        //    {
        //        "4151"
        //    };
        //    RootobjectOsrsGe specItem = new RootobjectOsrsGe();
        //    url = baseurl + "4151";
        //    specItem = DownloadedItemOsrsGe.Download_serialized_json_data(url);
        //    return View(specItem);
        //}
    }
}