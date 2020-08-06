using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OSRS_PRICE_WATCH.Models;
using OsrsBoxImplementation;
using static OsrsBoxImplementation.OsrsGe;
using Microsoft.AspNetCore.Identity;

namespace OSRS_PRICE_WATCH.Controllers
{
    public class ItemsController : Controller
    {
        private IFavoritesRepository repository;
        private UserManager<AppUser> userManager;
        public ItemsController(IFavoritesRepository repo, UserManager<AppUser> userMgr)
        {
            repository = repo;
            userManager = userMgr;
        }


        /*
         * Formats the search to input into OSRSBox Api
         * 
         * @variables:  searchedItems, _Items- used to gather the ID from the OSRSBox api to pass to 2nd API
         *              specificItem, RootobjectOsrsGe- used to gather GE information from the OSRS GE API
         * 
         */
        public IActionResult SingleItem(Items item)
        {
            
            item.Name = item.Name.ToLower();
            item.Name = char.ToUpper(item.Name[0]) + item.Name.Substring(1);
            ViewBag.ItemName = item.Name;
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

                TempData["Error"] = "Please enter a valid item name";
                return RedirectToAction("Stocks", "Home");
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
        public ActionResult SingleItem(RootobjectOsrsGe searchedItem)
        {
            if (ModelState.IsValid)
            {
                Items newItem = new Items();
                newItem.Name = searchedItem.item.name;
                ViewBag.ItemName = newItem.Name;
                return RedirectToAction("SingleItem", newItem);
            }
            else
            {
                TempData["Error"] = "Please enter a valid item name";
                return RedirectToAction("Stocks", "Home");
            }
        }
    }
}
