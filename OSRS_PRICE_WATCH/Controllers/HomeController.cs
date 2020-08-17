using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OSRS_PRICE_WATCH.Models;
using OsrsBoxImplementation;
using static OsrsBoxImplementation.OsrsGe;

namespace OSRS_PRICE_WATCH.Controllers
{
    public class HomeController : Controller
    {
        private IFavoritesRepository repository;

        public HomeController(IFavoritesRepository repo)
        {
            repository = repo;
        }

        public ViewResult About() => View();


        private Dictionary<string, object> GetData(string actionName) => new Dictionary<string, object>
        {
            ["Action"] = actionName,
            ["User"] = HttpContext.User.Identity.Name,
            ["Authenticated"] = HttpContext.User.Identity.IsAuthenticated,
            ["Auth Type"] = HttpContext.User.Identity.AuthenticationType,
            ["In Users Role"] = HttpContext.User.IsInRole("Users")
        };

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
         * Checks if a user is on mobile before sending
         * them to the stocks page.
         * 
         * If a mobile user is detected, it redirects them 
         * to a mobile friendly page.
         */

        public ActionResult Stocks()
        {
            if (RequestExtensions.IsMobileBrowser(HttpContext.Request) == true)
            {
                return View("Stocks.Mobile");
            }
            else
            {
                return View("Stocks");
            }
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
                var url = this.Request.Path;
                return RedirectToAction("SingleItem", "Items", item, url);
            }
            else
            {
                if (RequestExtensions.IsMobileBrowser(HttpContext.Request) == true)
                {
                    return View("Stocks.Mobile");
                }
                else
                {
                    return View("Stocks");
                }
            }
        }


    }
}