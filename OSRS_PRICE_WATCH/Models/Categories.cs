using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OSRS_PRICE_WATCH.Models
{
    public class Categories
    {
        public static List<string> Food = new List<string>()
        {
                "Shark",
                "Lobster",
                "Monkfish",
                "Tuna",
                "Saradomin brew(4)",
                "Swordfish"
        };
        
        public static List<string> Weapons = new List<string>()
        {
                "Abyssal whip",
                "Dragon scimitar",
                "Elder maul",
                "Ghrazi rapier",
                "Abyssal dagger",
                "Abyssal bludgeon",
        };

        public static List<string> Armor = new List<string>()
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

        public static List<string> Potions = new List<string>()
        {
                "Super restore(4)",
                "Divine super attack potion(4)",
                "Divine super strength potion(4)",
                "Ranging potion(4)",
                "Stamina potion(4)",
                "Saradomin brew(4)",
                "Super combat potion(4)"
        };

        public static List<string> Woodcutting = new List<string>()
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

        public static List<string> Mining = new List<string>()
        {
                "Copper ore",
                "Tin ore",
                "Silver ore",
                "Coal",
                "Mithril ore",
                "Adamantite ore",
                "Runite ore"


        };
    }
}
