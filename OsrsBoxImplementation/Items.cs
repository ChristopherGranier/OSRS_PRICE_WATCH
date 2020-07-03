using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OsrsBoxImplementation
{
    //This class is the implementation of the OsrsBox API
    //The method DownloadedItem() will navigate to a specified url
    //and download / deseralize a JSON file and import it into the 
    //respective classes.


    public class Rootobject
    {
        public _Items[] _items { get; set; }
        public _Links _links { get; set; }
        public _Meta _meta { get; set; }
    }

    public class _Links
    {
        public Parent parent { get; set; }
        public Self self { get; set; }
    }

    public class Parent
    {
        public string title { get; set; }
        public string href { get; set; }
    }

    public class Self
    {
        public string title { get; set; }
        public string href { get; set; }
    }

    public class _Meta
    {
        public int page { get; set; }
        public int max_results { get; set; }
        public int total { get; set; }
    }

    public class _Items
    {
        public string _id { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public bool incomplete { get; set; }
        public bool members { get; set; }
        public bool tradeable { get; set; }
        public bool tradeable_on_ge { get; set; }
        public bool stackable { get; set; }
        public object stacked { get; set; }
        public bool noted { get; set; }
        public bool noteable { get; set; }
        public object linked_id_item { get; set; }
        public int linked_id_noted { get; set; }
        public int linked_id_placeholder { get; set; }
        public bool placeholder { get; set; }
        public bool equipable { get; set; }
        public bool equipable_by_player { get; set; }
        public bool equipable_weapon { get; set; }
        public int cost { get; set; }
        public int lowalch { get; set; }
        public int highalch { get; set; }
        public float weight { get; set; }
        public int buy_limit { get; set; }
        public bool quest_item { get; set; }
        public string release_date { get; set; }
        public bool duplicate { get; set; }
        public string examine { get; set; }
        public string icon { get; set; }
        public string wiki_name { get; set; }
        public string wiki_url { get; set; }
        public Equipment equipment { get; set; }
        public Weapon weapon { get; set; }
        public string _created { get; set; }
        public string _updated { get; set; }
        public string _etag { get; set; }
        public _Links1 _links { get; set; }
    }

    public class Equipment
    {
        public int attack_stab { get; set; }
        public int attack_slash { get; set; }
        public int attack_crush { get; set; }
        public int attack_magic { get; set; }
        public int attack_ranged { get; set; }
        public int defence_stab { get; set; }
        public int defence_slash { get; set; }
        public int defence_crush { get; set; }
        public int defence_magic { get; set; }
        public int defence_ranged { get; set; }
        public int melee_strength { get; set; }
        public int ranged_strength { get; set; }
        public int magic_damage { get; set; }
        public int prayer { get; set; }
        public string slot { get; set; }
        public Requirements requirements { get; set; }
    }

    public class Requirements
    {
        public int attack { get; set; }
    }

    public class Weapon
    {
        public int attack_speed { get; set; }
        public string weapon_type { get; set; }
        public Stance[] stances { get; set; }
    }

    public class Stance
    {
        public string combat_style { get; set; }
        public string attack_type { get; set; }
        public string attack_style { get; set; }
        public string experience { get; set; }
        public object boosts { get; set; }
    }

    public class _Links1
    {
        public Self1 self { get; set; }
    }

    public class Self1
    {
        public string title { get; set; }
        public string href { get; set; }
    }




    public class DownloadedItem
    {
        public static _Items Download_serialized_json_data(string url)
        {
            using (var webClient = new WebClient())
            {
                string json_data = webClient.DownloadString(url);
                Rootobject obj = new Rootobject();
                obj = JsonConvert.DeserializeObject<Rootobject>(json_data);
                _Items id = new _Items();
                foreach (_Items i in obj._items)
                {
                    id = i;
                }

                return id;

            }
        }
    }

}