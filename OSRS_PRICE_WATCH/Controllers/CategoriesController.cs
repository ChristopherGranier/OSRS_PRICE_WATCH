using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleApp7;
using Microsoft.AspNetCore.Mvc;

namespace OSRS_PRICE_WATCH.Controllers
{
    public class CategoriesController : Controller
    {
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
                DesWeapons[i] = Test.Download_serialized_json_data(url);
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
                DesFood[i] = Test.Download_serialized_json_data(url);
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
                DesArmor[i] = Test.Download_serialized_json_data(url);
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
                DesPotions[i] = Test.Download_serialized_json_data(url);
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
                DesWoodcutting[i] = Test.Download_serialized_json_data(url);
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
                DesMining[i] = Test.Download_serialized_json_data(url);
            }
            return View(DesMining);
        }

        public ViewResult Runes()
        {
            var url = string.Empty;

            List<string> Runes = new List<string>()
            {
                "Air rune",
                "Mind rune",
                "Water rune",
                "Earth rune",
                "Fire rune",
                "Body rune",
                "Cosmic rune",
                "Chaos rune",
                "Nature rune",
                "Law rune",
                "Death rune",
                "Astral rune",
                "Blood rune",
                "Soul rune",
                "Wrath rune"
            };
            _Items[] DesRunes = new _Items[Runes.Count];
            for (int i = 0; i < Runes.Count(); i++)
            {
                url = "https://api.osrsbox.com/items?where={ \"name\": \"" + Runes[i] + "\", \"duplicate\": false }";
                DesRunes[i] = Test.Download_serialized_json_data(url);
            }
            return View(DesRunes);
        }
    }
}