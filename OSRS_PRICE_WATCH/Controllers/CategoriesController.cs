using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
         * 
         * Every action in this controller uses the same logic
         * 
         * 
         * @returns: _Items[] Des Weapons, data gathered from API
         */
        public ViewResult Weapons()
        {
            var url = string.Empty;

            List<string> Weapons = new List<string>()
            {
                "Abyssal whip",
                "Dragon scimitar",
                "Elder maul",
                "Ghrazi rapier",
                "Abyssal dagger",
                "Abyssal bludgeon",
            };
            _Items[] DesWeapons = new _Items[Weapons.Count];
            for (int i = 0; i < Weapons.Count(); i++)
            {
                url = "https://api.osrsbox.com/items?where={ \"name\": \"" + Weapons[i] + "\", \"duplicate\": false }";
                DesWeapons[i] = DownloadedItem.Download_serialized_json_data(url);
            }
            return View(DesWeapons);
        }

        public ViewResult Food()
        {
            var url = string.Empty;

            List<string> Food = new List<string>()
            {
                "Shark",
                "Lobster",
                "Monkfish",
                "Tuna",
                "Saradomin brew(4)",
                "Swordfish"
            };
            _Items[] DesFood = new _Items[Food.Count];
            for (int i = 0; i < Food.Count(); i++)
            {
                url = "https://api.osrsbox.com/items?where={ \"name\": \"" + Food[i] + "\", \"duplicate\": false }";
                DesFood[i] = DownloadedItem.Download_serialized_json_data(url);
            }
            return View(DesFood);
        }

        public ViewResult Armor()
        {
            var url = string.Empty;

            List<string> Armor = new List<string>()
            {
                "Berserker ring",
                "Bandos chestplate",
                "Bandos tassets",
                "Bandos boots",
                "Dragon full helm",
                "Justiciar faceguard",
                "Justiciar chestguard",
                "Justiciar legguards",
                "Helm of neitiznot",
                "Primordial boots"

            };
            _Items[] DesArmor = new _Items[Armor.Count];
            for (int i = 0; i < Armor.Count(); i++)
            {
                url = "https://api.osrsbox.com/items?where={ \"name\": \"" + Armor[i] + "\", \"duplicate\": false }";
                DesArmor[i] = DownloadedItem.Download_serialized_json_data(url);
            }
            return View(DesArmor);
        }

        public ViewResult Potions()
        {
            var url = string.Empty;

            List<string> Potions = new List<string>()
            {
                "Super restore(4)",
                "Divine super attack potion(4)",
                "Divine super strength potion(4)",
                "Divine super defense potion(4)",
                "Ranging potion(4)",
                "Stamina potion(4)",
                "Saradomin brew(4)",
                "Super combat potion(4)",
                "Anti-venom+(4)",
                "Extender super antifire(4)"
            };
            _Items[] DesPotions = new _Items[Potions.Count];
            for (int i = 0; i < Potions.Count(); i++)
            {
                url = "https://api.osrsbox.com/items?where={ \"name\": \"" + Potions[i] + "\", \"duplicate\": false }";
                DesPotions[i] = DownloadedItem.Download_serialized_json_data(url);
            }
            return View(DesPotions);
        }

        public ViewResult Woodcutting()
        {
            var url = string.Empty;

            List<string> Woodcutting = new List<string>()
            {
                "Logs",
                "Oak logs",
                "Willow logs",
                "Teak logs",
                "Maple logs",
                "Mahogany logs",
                "Yew logs",
                "Magic logs",
                "Redwood logs"
            };
            _Items[] DesWoodcutting = new _Items[Woodcutting.Count];
            for (int i = 0; i < Woodcutting.Count(); i++)
            {
                url = "https://api.osrsbox.com/items?where={ \"name\": \"" + Woodcutting[i] + "\", \"duplicate\": false }";
                DesWoodcutting[i] = DownloadedItem.Download_serialized_json_data(url);
            }
            return View(DesWoodcutting);
        }

        public ViewResult Mining()
        {
            var url = string.Empty;

            List<string> Mining = new List<string>()
            {
                "Copper ore",
                "Tin ore",
                "Silver ore",
                "Coal",
                "Mithril ore",
                "Adamant ore",
                "Runite ore"


            };
            _Items[] DesMining = new _Items[Mining.Count];
            for (int i = 0; i < Mining.Count(); i++)
            {
                url = "https://api.osrsbox.com/items?where={ \"name\": \"" + Mining[i] + "\", \"duplicate\": false }";
                DesMining[i] = DownloadedItem.Download_serialized_json_data(url);
            }
            return View(DesMining);
        }
    }
}