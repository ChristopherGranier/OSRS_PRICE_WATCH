using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OSRS_PRICE_WATCH.Models;
using OsrsBoxImplementation;

namespace OSRS_PRICE_WATCH.Controllers
{
    //This controller is specifically to return a view 
    //which displays a set # of items in a specific category
    //eg. weapons
    public class CategoriesController : Controller
    {


        /*
         * Populates an instance of the _Items[] class
         * with predefined items to be gathered from the api 
         * gathered from the Categories class
         * 
         * Every action in this controller uses the same logic
         * 
         * 
         * @returns: _Items[] Des Weapons, data gathered from API
         */
        public ViewResult Weapons()
        {
            var url = string.Empty;
            _Items[] DesWeapons = new _Items[Categories.Weapons.Count];
            for (int i = 0; i < Categories.Weapons.Count(); i++)
            {
                url = "https://api.osrsbox.com/items?where={ \"name\": \"" + Categories.Weapons[i] + "\", \"duplicate\": false }";
                DesWeapons[i] = DownloadedItem.Download_serialized_json_data(url);
            }
            TempData["Category"] = "Weapons";
            return View("Categories", DesWeapons);
        }

        public ViewResult Food()
        {
            var url = string.Empty;
            List<_Items> DesFood = new List<_Items>();
            for (int i = 0; i < Categories.Food.Count(); i++)
            {
                url = "https://api.osrsbox.com/items?where={ \"name\": \"" + Categories.Food[i] + "\", \"duplicate\": false }";
                DesFood.Add(DownloadedItem.Download_serialized_json_data(url));
            }
            TempData["Category"] = "Food";

            _Items[] food = new _Items[Categories.Potions.Count()];
            food = DesFood.ToArray();



            return View("Categories", food);

        }

        public ViewResult Armor()
        {
            var url = string.Empty;

            _Items[] DesArmor = new _Items[Categories.Armor.Count];
            for (int i = 0; i < Categories.Armor.Count(); i++)
            {
                url = "https://api.osrsbox.com/items?where={ \"name\": \"" + Categories.Armor[i] + "\", \"duplicate\": false }";
                DesArmor[i] = DownloadedItem.Download_serialized_json_data(url);
            }
            TempData["Category"] = "Armor";


            return View("Categories", DesArmor);
        }

        public ViewResult Potions()
        {
            var url = string.Empty;
            _Items[] DesPotions = new _Items[Categories.Potions.Count];
            for (int i = 0; i < Categories.Potions.Count(); i++)
            {
                url = "https://api.osrsbox.com/items?where={ \"name\": \"" + Categories.Potions[i] + "\", \"duplicate\": false }";
                DesPotions[i] = DownloadedItem.Download_serialized_json_data(url);
            }
            TempData["Category"] = "Potions";


            return View("Categories", DesPotions);
        }

        public ViewResult Woodcutting()
        {
            var url = string.Empty;
            _Items[] DesWoodcutting = new _Items[Categories.Woodcutting.Count];
            for (int i = 0; i < Categories.Woodcutting.Count(); i++)
            {
                url = "https://api.osrsbox.com/items?where={ \"name\": \"" + Categories.Woodcutting[i] + "\", \"duplicate\": false }";
                DesWoodcutting[i] = DownloadedItem.Download_serialized_json_data(url);
            }
            TempData["Category"] = "Woodcutting";


            return View("Categories", DesWoodcutting);
        }

        public ViewResult Mining()
        {
            var url = string.Empty;
            _Items[] DesMining = new _Items[Categories.Mining.Count];
            for (int i = 0; i < Categories.Mining.Count(); i++)
            {
                url = "https://api.osrsbox.com/items?where={ \"name\": \"" + Categories.Mining[i] + "\", \"duplicate\": false }";
                DesMining[i] = DownloadedItem.Download_serialized_json_data(url);
            }
            TempData["Category"] = "Mining";


            return View("Categories", DesMining);
        }

        /*
         * Gathers the predefined item list from the categories
         * class based on which category is being sorted
         * 
         * Sorts the items displayed by name
         * 
         */
        public ViewResult NameFilter(int id)
        {
            var category = TempData["Category"];

            switch (category)
            {
                case "Potions":
                    var url = string.Empty;
                    List<_Items> DesPotions = new List<_Items>();
                    for (int i = 0; i < Categories.Potions.Count(); i++)
                    {
                        url = "https://api.osrsbox.com/items?where={ \"name\": \"" + Categories.Potions[i] + "\", \"duplicate\": false }";
                        DesPotions.Add(DownloadedItem.Download_serialized_json_data(url));
                    }
                    TempData["Category"] = "Potions";

                    List<_Items> sortedList = DesPotions.OrderBy(n => n.wiki_name).ToList();
                    if (TempData["Sorted"] == null || TempData["Sorted"].Equals("high"))
                    {
                        _Items[] desPotionsSortedName = new _Items[Categories.Potions.Count()];
                        desPotionsSortedName = sortedList.ToArray();
                        TempData["Sorted"] = "low";

                        return View("Categories", desPotionsSortedName);
                    }
                    else
                    {
                        sortedList.Reverse();
                        TempData["Sorted"] = "high";
                        _Items[] desPotionsSortedName = new _Items[Categories.Potions.Count()];
                        desPotionsSortedName = sortedList.ToArray();
                        return View("Categories", desPotionsSortedName);
                    }

                case "Weapons":
                    url = string.Empty;
                    List<_Items> DesWeapons = new List<_Items>();
                    for (int i = 0; i < Categories.Weapons.Count(); i++)
                    {
                        url = "https://api.osrsbox.com/items?where={ \"name\": \"" + Categories.Weapons[i] + "\", \"duplicate\": false }";
                        DesWeapons.Add(DownloadedItem.Download_serialized_json_data(url));
                    }
                    TempData["Category"] = "Weapons";

                    sortedList = DesWeapons.OrderBy(p => p.wiki_name).ToList();
                    if (TempData["Sorted"] == null || TempData["Sorted"].Equals("high"))
                    {
                        _Items[] desWeaponsSortedName = new _Items[Categories.Potions.Count()];
                        desWeaponsSortedName = sortedList.ToArray();
                        TempData["Sorted"] = "low";

                        return View("Categories", desWeaponsSortedName);
                    }
                    else
                    {
                        sortedList.Reverse();
                        TempData["Sorted"] = "high";
                        _Items[] desWeaponsSortedName = new _Items[Categories.Potions.Count()];
                        desWeaponsSortedName = sortedList.ToArray();
                        return View("Categories", desWeaponsSortedName);
                    }

                case "Food":
                    url = string.Empty;
                    List<_Items> DesFood = new List<_Items>();
                    for (int i = 0; i < Categories.Food.Count(); i++)
                    {
                        url = "https://api.osrsbox.com/items?where={ \"name\": \"" + Categories.Food[i] + "\", \"duplicate\": false }";
                        DesFood.Add(DownloadedItem.Download_serialized_json_data(url));
                    }
                    TempData["Category"] = "Food";

                    sortedList = DesFood.OrderBy(p => p.wiki_url).ToList();
                    if (TempData["Sorted"] == null || TempData["Sorted"].Equals("high"))
                    {
                        _Items[] desFoodSortedName = new _Items[Categories.Potions.Count()];
                        desFoodSortedName = sortedList.ToArray();
                        TempData["Sorted"] = "low";

                        return View("Categories", desFoodSortedName);
                    }
                    else
                    {
                        sortedList.Reverse();
                        TempData["Sorted"] = "high";
                        _Items[] desFoodSortedName = new _Items[Categories.Potions.Count()];
                        desFoodSortedName = sortedList.ToArray();
                        return View("Categories", desFoodSortedName);
                    }

                case "Armor":
                    url = string.Empty;
                    List<_Items> DesArmor = new List<_Items>();
                    for (int i = 0; i < Categories.Armor.Count(); i++)
                    {
                        url = "https://api.osrsbox.com/items?where={ \"name\": \"" + Categories.Armor[i] + "\", \"duplicate\": false }";
                        DesArmor.Add(DownloadedItem.Download_serialized_json_data(url));
                    }
                    TempData["Category"] = "Armor";

                    sortedList = DesArmor.OrderBy(p => p.wiki_url).ToList();
                    if (TempData["Sorted"] == null || TempData["Sorted"].Equals("high"))
                    {
                        _Items[] desArmorSortedPrice = new _Items[Categories.Potions.Count()];
                        desArmorSortedPrice = sortedList.ToArray();
                        TempData["Sorted"] = "low";

                        return View("Categories", desArmorSortedPrice);
                    }
                    else
                    {
                        sortedList.Reverse();
                        TempData["Sorted"] = "high";
                        _Items[] desArmorSortedPrice = new _Items[Categories.Potions.Count()];
                        desArmorSortedPrice = sortedList.ToArray();
                        return View("Categories", desArmorSortedPrice);
                    }

                case "Woodcutting":
                    url = string.Empty;
                    List<_Items> DesWoodcutting = new List<_Items>();
                    for (int i = 0; i < Categories.Woodcutting.Count(); i++)
                    {
                        url = "https://api.osrsbox.com/items?where={ \"name\": \"" + Categories.Woodcutting[i] + "\", \"duplicate\": false }";
                        DesWoodcutting.Add(DownloadedItem.Download_serialized_json_data(url));
                    }
                    TempData["Category"] = "Woodcutting";

                    sortedList = DesWoodcutting.OrderBy(p => p.wiki_name).ToList();
                    if (TempData["Sorted"] == null || TempData["Sorted"].Equals("high"))
                    {
                        _Items[] desWoodcuttingSortedPrice = new _Items[Categories.Potions.Count()];
                        desWoodcuttingSortedPrice = sortedList.ToArray();
                        TempData["Sorted"] = "low";

                        return View("Categories", desWoodcuttingSortedPrice);
                    }
                    else
                    {
                        sortedList.Reverse();
                        TempData["Sorted"] = "high";
                        _Items[] desWoodcuttingSortedPrice = new _Items[Categories.Potions.Count()];
                        desWoodcuttingSortedPrice = sortedList.ToArray();
                        return View("Categories", desWoodcuttingSortedPrice);
                    }

                case "Mining":
                    url = string.Empty;
                    List<_Items> DesMining = new List<_Items>();
                    for (int i = 0; i < Categories.Mining.Count(); i++)
                    {
                        url = "https://api.osrsbox.com/items?where={ \"name\": \"" + Categories.Mining[i] + "\", \"duplicate\": false }";
                        DesMining.Add(DownloadedItem.Download_serialized_json_data(url));
                    }
                    TempData["Category"] = "Mining";

                    sortedList = DesMining.OrderBy(p => p.wiki_name).ToList();
                    if (TempData["Sorted"] == null || TempData["Sorted"].Equals("high"))
                    {
                        _Items[] desMiningSortedPrice = new _Items[Categories.Potions.Count()];
                        desMiningSortedPrice = sortedList.ToArray();
                        TempData["Sorted"] = "low";

                        return View("Categories", desMiningSortedPrice);
                    }
                    else
                    {
                        sortedList.Reverse();
                        TempData["Sorted"] = "high";
                        _Items[] desMiningSortedPrice = new _Items[Categories.Potions.Count()];
                        desMiningSortedPrice = sortedList.ToArray();
                        return View("Categories", desMiningSortedPrice);
                    }
            }
            return View();
        }

  

        /*
        * Gathers the predefined item list from the categories
        * class based on which category is being sorted
        * 
        * Sorts the items displayed by price
        * 
        */
        public ViewResult PriceFilter(int id)
        {
            var category = TempData["Category"];

            switch (category)
            {
                case "Potions":
                    var url = string.Empty;
                    List<_Items> DesPotions = new List<_Items>();
                    for (int i = 0; i < Categories.Potions.Count(); i++)
                    {
                        url = "https://api.osrsbox.com/items?where={ \"name\": \"" + Categories.Potions[i] + "\", \"duplicate\": false }";
                        DesPotions.Add(DownloadedItem.Download_serialized_json_data(url));
                    }
                    TempData["Category"] = "Potions";

                    List<_Items> sortedList = DesPotions.OrderBy(p => p.cost).ToList();
                    if (TempData["Sorted"] == null || TempData["Sorted"].Equals("high"))
                    {
                        _Items[] desPotionsSortedPrice = new _Items[Categories.Potions.Count()];
                        desPotionsSortedPrice = sortedList.ToArray();
                        TempData["Sorted"] = "low";

                        return View("Categories", desPotionsSortedPrice);
                    }
                    else
                    {
                        sortedList.Reverse();
                        TempData["Sorted"] = "high";
                        _Items[] desPotionsSortedPrice = new _Items[Categories.Potions.Count()];
                        desPotionsSortedPrice = sortedList.ToArray();
                        return View("Categories", desPotionsSortedPrice);
                    }                    

                case "Weapons":
                    url = string.Empty;
                    List<_Items> DesWeapons = new List<_Items>();
                    for (int i = 0; i < Categories.Weapons.Count(); i++)
                    {
                        url = "https://api.osrsbox.com/items?where={ \"name\": \"" + Categories.Weapons[i] + "\", \"duplicate\": false }";
                        DesWeapons.Add(DownloadedItem.Download_serialized_json_data(url));
                    }
                    TempData["Category"] = "Weapons";

                    sortedList = DesWeapons.OrderBy(p => p.cost).ToList();
                    if (TempData["Sorted"] == null || TempData["Sorted"].Equals("high"))
                    {
                        _Items[] desWeaponsSortedPrice = new _Items[Categories.Potions.Count()];
                        desWeaponsSortedPrice = sortedList.ToArray();
                        TempData["Sorted"] = "low";

                        return View("Categories", desWeaponsSortedPrice);
                    }
                    else
                    {
                        sortedList.Reverse();
                        TempData["Sorted"] = "high";
                        _Items[] desWeaponsSortedPrice = new _Items[Categories.Potions.Count()];
                        desWeaponsSortedPrice = sortedList.ToArray();
                        return View("Categories", desWeaponsSortedPrice);
                    }

                case "Food":
                    url = string.Empty;
                    List<_Items> DesFood = new List<_Items>();
                    for (int i = 0; i < Categories.Food.Count(); i++)
                    {
                        url = "https://api.osrsbox.com/items?where={ \"name\": \"" + Categories.Food[i] + "\", \"duplicate\": false }";
                        DesFood.Add(DownloadedItem.Download_serialized_json_data(url));
                    }
                    TempData["Category"] = "Food";

                    sortedList = DesFood.OrderBy(p => p.cost).ToList();
                    if (TempData["Sorted"] == null || TempData["Sorted"].Equals("high"))
                    {
                        _Items[] desFoodSortedPrice = new _Items[Categories.Potions.Count()];
                        desFoodSortedPrice = sortedList.ToArray();
                        TempData["Sorted"] = "low";

                        return View("Categories", desFoodSortedPrice);
                    }
                    else
                    {
                        sortedList.Reverse();
                        TempData["Sorted"] = "high";
                        _Items[] desFoodSortedPrice = new _Items[Categories.Potions.Count()];
                        desFoodSortedPrice = sortedList.ToArray();
                        return View("Categories", desFoodSortedPrice);
                    }

                case "Armor":
                    url = string.Empty;
                    List<_Items> DesArmor = new List<_Items>();
                    for (int i = 0; i < Categories.Armor.Count(); i++)
                    {
                        url = "https://api.osrsbox.com/items?where={ \"name\": \"" + Categories.Armor[i] + "\", \"duplicate\": false }";
                        DesArmor.Add(DownloadedItem.Download_serialized_json_data(url));
                    }
                    TempData["Category"] = "Armor";

                    sortedList = DesArmor.OrderBy(p => p.cost).ToList();
                    if (TempData["Sorted"] == null || TempData["Sorted"].Equals("high"))
                    {
                        _Items[] desArmorSortedPrice = new _Items[Categories.Potions.Count()];
                        desArmorSortedPrice = sortedList.ToArray();
                        TempData["Sorted"] = "low";

                        return View("Categories", desArmorSortedPrice);
                    }
                    else
                    {
                        sortedList.Reverse();
                        TempData["Sorted"] = "high";
                        _Items[] desArmorSortedPrice = new _Items[Categories.Potions.Count()];
                        desArmorSortedPrice = sortedList.ToArray();
                        return View("Categories", desArmorSortedPrice);
                    }

                case "Woodcutting":
                    url = string.Empty;
                    List<_Items> DesWoodcutting = new List<_Items>();
                    for (int i = 0; i < Categories.Woodcutting.Count(); i++)
                    {
                        url = "https://api.osrsbox.com/items?where={ \"name\": \"" + Categories.Woodcutting[i] + "\", \"duplicate\": false }";
                        DesWoodcutting.Add(DownloadedItem.Download_serialized_json_data(url));
                    }
                    TempData["Category"] = "Woodcutting";

                    sortedList = DesWoodcutting.OrderBy(p => p.cost).ToList();
                    if (TempData["Sorted"] == null || TempData["Sorted"].Equals("high"))
                    {
                        _Items[] desWoodcuttingSortedPrice = new _Items[Categories.Potions.Count()];
                        desWoodcuttingSortedPrice = sortedList.ToArray();
                        TempData["Sorted"] = "low";

                        return View("Categories", desWoodcuttingSortedPrice);
                    }
                    else
                    {
                        sortedList.Reverse();
                        TempData["Sorted"] = "high";
                        _Items[] desWoodcuttingSortedPrice = new _Items[Categories.Potions.Count()];
                        desWoodcuttingSortedPrice = sortedList.ToArray();
                        return View("Categories", desWoodcuttingSortedPrice);
                    }

                case "Mining":
                    url = string.Empty;
                    List<_Items> DesMining = new List<_Items>();
                    for (int i = 0; i < Categories.Mining.Count(); i++)
                    {
                        url = "https://api.osrsbox.com/items?where={ \"name\": \"" + Categories.Mining[i] + "\", \"duplicate\": false }";
                        DesMining.Add(DownloadedItem.Download_serialized_json_data(url));
                    }
                    TempData["Category"] = "Mining";

                    sortedList = DesMining.OrderBy(p => p.cost).ToList();
                    if (TempData["Sorted"] == null || TempData["Sorted"].Equals("high"))
                    {
                        _Items[] desMiningSortedPrice = new _Items[Categories.Potions.Count()];
                        desMiningSortedPrice = sortedList.ToArray();
                        TempData["Sorted"] = "low";

                        return View("Categories", desMiningSortedPrice);
                    }
                    else
                    {
                        sortedList.Reverse();
                        TempData["Sorted"] = "high";
                        _Items[] desMiningSortedPrice = new _Items[Categories.Potions.Count()];
                        desMiningSortedPrice = sortedList.ToArray();
                        return View("Categories", desMiningSortedPrice);
                    }
            }
            return View();
        }

        /*
        * Gathers the predefined item list from the categories
        * class based on which category is being sorted
        * 
        * Sorts the items displayed by high alch value
        * 
        */
        public ViewResult HAFilter(int id)
        {
            var category = TempData["Category"];

            switch (category)
            {
                case "Potions":
                    var url = string.Empty;
                    List<_Items> DesPotions = new List<_Items>();
                    for (int i = 0; i < Categories.Potions.Count(); i++)
                    {
                        url = "https://api.osrsbox.com/items?where={ \"name\": \"" + Categories.Potions[i] + "\", \"duplicate\": false }";
                        DesPotions.Add(DownloadedItem.Download_serialized_json_data(url));
                    }
                    TempData["Category"] = "Potions";

                    List<_Items> sortedList = DesPotions.OrderBy(n => n.highalch).ToList();
                    if (TempData["Sorted"] == null || TempData["Sorted"].Equals("high"))
                    {
                        _Items[] desPotionsSortedHA = new _Items[Categories.Potions.Count()];
                        desPotionsSortedHA = sortedList.ToArray();
                        TempData["Sorted"] = "low";

                        return View("Categories", desPotionsSortedHA);
                    }
                    else
                    {
                        sortedList.Reverse();
                        TempData["Sorted"] = "high";
                        _Items[] desPotionsSortedHA = new _Items[Categories.Potions.Count()];
                        desPotionsSortedHA = sortedList.ToArray();
                        return View("Categories", desPotionsSortedHA);
                    }

                case "Weapons":
                    url = string.Empty;
                    List<_Items> DesWeapons = new List<_Items>();
                    for (int i = 0; i < Categories.Weapons.Count(); i++)
                    {
                        url = "https://api.osrsbox.com/items?where={ \"name\": \"" + Categories.Weapons[i] + "\", \"duplicate\": false }";
                        DesWeapons.Add(DownloadedItem.Download_serialized_json_data(url));
                    }
                    TempData["Category"] = "Weapons";

                    sortedList = DesWeapons.OrderBy(p => p.highalch).ToList();
                    if (TempData["Sorted"] == null || TempData["Sorted"].Equals("high"))
                    {
                        _Items[] desWeaponsSortedHA = new _Items[Categories.Potions.Count()];
                        desWeaponsSortedHA = sortedList.ToArray();
                        TempData["Sorted"] = "low";

                        return View("Categories", desWeaponsSortedHA);
                    }
                    else
                    {
                        sortedList.Reverse();
                        TempData["Sorted"] = "high";
                        _Items[] desWeaponsSortedHA = new _Items[Categories.Potions.Count()];
                        desWeaponsSortedHA = sortedList.ToArray();
                        return View("Categories", desWeaponsSortedHA);
                    }
 

                case "Food":
                    url = string.Empty;
                    List<_Items> DesFood = new List<_Items>();
                    for (int i = 0; i < Categories.Food.Count(); i++)
                    {
                        url = "https://api.osrsbox.com/items?where={ \"name\": \"" + Categories.Food[i] + "\", \"duplicate\": false }";
                        DesFood.Add(DownloadedItem.Download_serialized_json_data(url));
                    }
                    TempData["Category"] = "Food";

                    sortedList = DesFood.OrderBy(p => p.highalch).ToList();
                    if (TempData["Sorted"] == null || TempData["Sorted"].Equals("high"))
                    {
                        _Items[] desFoodSortedHA = new _Items[Categories.Potions.Count()];
                        desFoodSortedHA = sortedList.ToArray();
                        TempData["Sorted"] = "low";

                        return View("Categories", desFoodSortedHA);
                    }
                    else
                    {
                        sortedList.Reverse();
                        TempData["Sorted"] = "high";
                        _Items[] desFoodSortedHA = new _Items[Categories.Potions.Count()];
                        desFoodSortedHA = sortedList.ToArray();
                        return View("Categories", desFoodSortedHA);
                    }

                case "Armor":
                    url = string.Empty;
                    List<_Items> DesArmor = new List<_Items>();
                    for (int i = 0; i < Categories.Armor.Count(); i++)
                    {
                        url = "https://api.osrsbox.com/items?where={ \"name\": \"" + Categories.Armor[i] + "\", \"duplicate\": false }";
                        DesArmor.Add(DownloadedItem.Download_serialized_json_data(url));
                    }
                    TempData["Category"] = "Armor";

                    sortedList = DesArmor.OrderBy(p => p.highalch).ToList();
                    if (TempData["Sorted"] == null || TempData["Sorted"].Equals("high"))
                    {
                        _Items[] desArmorSortedHA = new _Items[Categories.Potions.Count()];
                        desArmorSortedHA = sortedList.ToArray();
                        TempData["Sorted"] = "low";

                        return View("Categories", desArmorSortedHA);
                    }
                    else
                    {
                        sortedList.Reverse();
                        TempData["Sorted"] = "high";
                        _Items[] desArmorSortedHA = new _Items[Categories.Potions.Count()];
                        desArmorSortedHA = sortedList.ToArray();
                        return View("Categories", desArmorSortedHA);
                    }

                case "Woodcutting":
                    url = string.Empty;
                    List<_Items> DesWoodcutting = new List<_Items>();
                    for (int i = 0; i < Categories.Woodcutting.Count(); i++)
                    {
                        url = "https://api.osrsbox.com/items?where={ \"name\": \"" + Categories.Woodcutting[i] + "\", \"duplicate\": false }";
                        DesWoodcutting.Add(DownloadedItem.Download_serialized_json_data(url));
                    }
                    TempData["Category"] = "Woodcutting";

                    sortedList = DesWoodcutting.OrderBy(p => p.highalch).ToList();
                    if (TempData["Sorted"] == null || TempData["Sorted"].Equals("high"))
                    {
                        _Items[] desWoodcuttingSortedHA = new _Items[Categories.Potions.Count()];
                        desWoodcuttingSortedHA = sortedList.ToArray();
                        TempData["Sorted"] = "low";

                        return View("Categories", desWoodcuttingSortedHA);
                    }
                    else
                    {
                        sortedList.Reverse();
                        TempData["Sorted"] = "high";
                        _Items[] desWoodcuttingSortedHA = new _Items[Categories.Potions.Count()];
                        desWoodcuttingSortedHA = sortedList.ToArray();
                        return View("Categories", desWoodcuttingSortedHA);
                    }

                case "Mining":
                    url = string.Empty;
                    List<_Items> DesMining = new List<_Items>();
                    for (int i = 0; i < Categories.Mining.Count(); i++)
                    {
                        url = "https://api.osrsbox.com/items?where={ \"name\": \"" + Categories.Mining[i] + "\", \"duplicate\": false }";
                        DesMining.Add(DownloadedItem.Download_serialized_json_data(url));
                    }
                    TempData["Category"] = "Mining";

                    sortedList = DesMining.OrderBy(p => p.highalch).ToList();
                    if (TempData["Sorted"] == null || TempData["Sorted"].Equals("high"))
                    {
                        _Items[] desMiningSortedHA = new _Items[Categories.Potions.Count()];
                        desMiningSortedHA = sortedList.ToArray();
                        TempData["Sorted"] = "low";

                        return View("Categories", desMiningSortedHA);
                    }
                    else
                    {
                        sortedList.Reverse();
                        TempData["Sorted"] = "high";
                        _Items[] desMiningSortedHA = new _Items[Categories.Potions.Count()];
                        desMiningSortedHA = sortedList.ToArray();
                        return View("Categories", desMiningSortedHA);
                    }
            }
            return View();
        }
    }
}