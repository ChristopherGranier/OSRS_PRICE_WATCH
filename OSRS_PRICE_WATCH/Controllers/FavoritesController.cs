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

        public ViewResult MyFavorites()
        {
            List<FavoriteModel> favorites = repository.Items.Where(i => i.Username == HttpContext.User.Identity.Name).ToList();
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
            }

            TempData["Username"] = HttpContext.User.Identity.Name;
            return View("MyFavorites", itemFavorites);
        }



        public IActionResult SaveItem(RootobjectOsrsGe items)
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
                return RedirectToAction("Success");

            }
            else
            {
                return RedirectToAction("TryAgain");
            }
        }

        public IActionResult Success() => View();
        public IActionResult Tryagain() => View();
    }
}