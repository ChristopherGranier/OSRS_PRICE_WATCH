using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OSRS_PRICE_WATCH.Models;
using OsrsBoxImplementation;
using static OsrsBoxImplementation.OsrsGe;
using Microsoft.EntityFrameworkCore;

namespace OSRS_PRICE_WATCH.Controllers
{
    [Authorize]
    public class FavoritesController : Controller
    {
        private IFavoritesRepository repository;
        private UserManager<AppUser> userManager;
        public FavoritesController(IFavoritesRepository repo, UserManager<AppUser> userMgr)
        {
            repository = repo;
            userManager = userMgr;
        }
        public IActionResult Success(string temp)
        {
            return Redirect(temp);
        }


        public IActionResult Tryagain(string temp)
        {
            return Redirect(temp);
        }

        /*
        * Pulls a users favorite items from the database 
        * and displays a table for them to view the
        * items that they favorited
        * 
        */
        public ViewResult MyFavorites()
        {
            List<FavoriteModel> favorites = repository.Items.Where(i => i.Username == HttpContext.User.Identity.Name).Distinct().ToList();
            var url = string.Empty;
            RootobjectOsrsGe[] favoritesArr = new RootobjectOsrsGe[favorites.Count()];
            for (int i = 0; i < favorites.Count(); i++)
            {
                url = "https://secure.runescape.com/m=itemdb_oldschool/api/catalogue/detail.json?item=" + favorites[i].ItemID;

                favoritesArr[i] = DownloadedItemOsrsGe.Download_serialized_json_data(url);
            }

            _Items[] itemFavorites = new _Items[favorites.Count()];
            for (int i = 0; i < favorites.Count(); i++)
            {
                url = "https://api.osrsbox.com/items?where={ \"name\": \"" + favoritesArr[i].item.name + "\", \"duplicate\": false }";
                itemFavorites[i] = DownloadedItem.Download_serialized_json_data(url);
                itemFavorites[i].price = favoritesArr[i].item.current.price;
            }
 
            TempData["Username"] = HttpContext.User.Identity.Name;
            TempData["Favorite"] = "true";
            
            return View("MyFavorites", itemFavorites);
        }


        /*
        * Action that allows a user to save an item
        * to view later on the MyFavorites page
        * 
        */
        public IActionResult SaveItem(RootobjectOsrsGe items, string returnUrl)
        {
            var url = "https://api.osrsbox.com/items?where={ \"name\": \"" + items.item.name + "\", \"duplicate\": false }";
            _Items nameToId = new _Items();
            nameToId = DownloadedItem.Download_serialized_json_data(url);
            url = "https://secure.runescape.com/m=itemdb_oldschool/api/catalogue/detail.json?item=" + nameToId.id;
            RootobjectOsrsGe itemID = new RootobjectOsrsGe();
            itemID = DownloadedItemOsrsGe.Download_serialized_json_data(url);
            FavoriteModel favorite = new FavoriteModel
            {
                ItemID = itemID.item.id.ToString(),
                Username = HttpContext.User.Identity.Name
            };
            if (repository.SaveFavorite(favorite) == 1)
            {

                TempData["Result"] = "Item successfully added to favorites";

                return Redirect(returnUrl);

            }
            else if (repository.SaveFavorite(favorite) == 0)
            {
                TempData["Result"] = "This item is already in your favorites";
                return Redirect(returnUrl);
            }
            else
            {
                TempData["Result"] = "Something went wrong with adding this item";
                return Redirect(returnUrl);
            }
        }

        /*
         * Removes an item from the favorites page
         */
        public IActionResult RemoveItem(_Items item)
        {
            
            
            FavoriteModel model = new FavoriteModel();
            model = (repository.Items.FirstOrDefault(i => i.ItemID == item.id && i.Username == HttpContext.User.Identity.Name)); 
            repository.DeleteFavorite(model);
            return RedirectToAction("MyFavorites");
        }



        /*
         * Filters for the MyFavorites page which filters by
         * name, price, and high alch value
         * 
         * 
         */
        public IActionResult PriceFilter(int id)
        {
            var url = string.Empty;
            List<FavoriteModel> favorites = repository.Items.Where(i => i.Username == HttpContext.User.Identity.Name).Distinct().ToList();
            RootobjectOsrsGe[] favoritesArr = new RootobjectOsrsGe[favorites.Count()];

            for (int i = 0; i < favorites.Count; i++)
            {
                url = "https://secure.runescape.com/m=itemdb_oldschool/api/catalogue/detail.json?item=" + favorites[i].ItemID;
                favoritesArr[i] = (DownloadedItemOsrsGe.Download_serialized_json_data(url));
            }
            _Items[] prices = new _Items[favorites.Count()];
            for (int i = 0; i < favorites.Count; i++)
            {
                url = "https://api.osrsbox.com/items?where={ \"name\": \"" + favoritesArr[i].item.name + "\", \"duplicate\": false }";
                prices[i] = (DownloadedItem.Download_serialized_json_data(url));
                prices[i].price = favoritesArr[i].item.current.price;
            }
            
            List<_Items> sortedList = prices.OrderBy(p => p.cost).ToList();
            _Items[] sortedPrice = new _Items[favorites.Count()];
            sortedPrice = sortedList.ToArray();
            TempData["Username"] = HttpContext.User.Identity.Name;
            if (TempData["Sorted"] == null || TempData["Sorted"].Equals("high"))
            {
                sortedPrice = new _Items[favorites.Count()];
                sortedPrice = sortedList.ToArray();
                TempData["Sorted"] = "low";

                return View("MyFavorites", sortedPrice);
            }
            else
            {
                sortedList.Reverse();
                TempData["Sorted"] = "high";
                sortedPrice = new _Items[Categories.Potions.Count()];
                sortedPrice = sortedList.ToArray();
                return View("MyFavorites", sortedPrice);
            }
        }

        public IActionResult HAFilter(int id)
        {
            var url = string.Empty;
            List<FavoriteModel> favorites = repository.Items.Where(i => i.Username == HttpContext.User.Identity.Name).Distinct().ToList();
            RootobjectOsrsGe[] favoritesArr = new RootobjectOsrsGe[favorites.Count()];

            for (int i = 0; i < favorites.Count; i++)
            {
                url = "https://secure.runescape.com/m=itemdb_oldschool/api/catalogue/detail.json?item=" + favorites[i].ItemID;
                favoritesArr[i] = (DownloadedItemOsrsGe.Download_serialized_json_data(url));
            }
            _Items[] highAlch = new _Items[favorites.Count()];
            for (int i = 0; i < favorites.Count; i++)
            {
                url = "https://api.osrsbox.com/items?where={ \"name\": \"" + favoritesArr[i].item.name + "\", \"duplicate\": false }";
                highAlch[i] = (DownloadedItem.Download_serialized_json_data(url));
                highAlch[i].price = favoritesArr[i].item.current.price;
            }

            List<_Items> sortedList = highAlch.OrderBy(p => p.highalch).ToList();
            _Items[] sortedHa = new _Items[favorites.Count()];
            sortedHa = sortedList.ToArray();
            TempData["Username"] = HttpContext.User.Identity.Name;
            if (TempData["Sorted"] == null || TempData["Sorted"].Equals("high"))
            {
                sortedHa = new _Items[favorites.Count()];
                sortedHa = sortedList.ToArray();
                TempData["Sorted"] = "low";

                return View("MyFavorites", sortedHa);
            }
            else
            {
                sortedList.Reverse();
                TempData["Sorted"] = "high";
                sortedHa = new _Items[Categories.Potions.Count()];
                sortedHa = sortedList.ToArray();
                return View("MyFavorites", sortedHa);
            }
        }

        public IActionResult NameFilter(int id)
        {
            var url = string.Empty;
            List<FavoriteModel> favorites = repository.Items.Where(i => i.Username == HttpContext.User.Identity.Name).Distinct().ToList();
            RootobjectOsrsGe[] favoritesArr = new RootobjectOsrsGe[favorites.Count()];

            for (int i = 0; i < favorites.Count; i++)
            {
                url = "https://secure.runescape.com/m=itemdb_oldschool/api/catalogue/detail.json?item=" + favorites[i].ItemID;
                favoritesArr[i] = (DownloadedItemOsrsGe.Download_serialized_json_data(url));
            }
            _Items[] names = new _Items[favorites.Count()];
            for (int i = 0; i < favorites.Count; i++)
            {
                url = "https://api.osrsbox.com/items?where={ \"name\": \"" + favoritesArr[i].item.name + "\", \"duplicate\": false }";
                names[i] = (DownloadedItem.Download_serialized_json_data(url));
                names[i].price = favoritesArr[i].item.current.price;
            }

            List<_Items> sortedList = names.OrderBy(p => p.name).ToList();
            _Items[] sortedName = new _Items[favorites.Count()];
            sortedName = sortedList.ToArray();
            TempData["Username"] = HttpContext.User.Identity.Name;
            if (TempData["Sorted"] == null || TempData["Sorted"].Equals("high"))
            {
                sortedName = new _Items[favorites.Count()];
                sortedName = sortedList.ToArray();
                TempData["Sorted"] = "low";

                return View("MyFavorites", sortedName);
            }
            else
            {
                sortedList.Reverse();
                TempData["Sorted"] = "high";
                sortedName = new _Items[Categories.Potions.Count()];
                sortedName = sortedList.ToArray();
                return View("MyFavorites", sortedName);
            }
        }
    }
}