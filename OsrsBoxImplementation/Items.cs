using System;
using System.Net;
using Newtonsoft.Json;

namespace OsrsBoxImplementation
{

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
        public Next next { get; set; }
        public Last last { get; set; }
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

    public class Next
    {
        public string title { get; set; }
        public string href { get; set; }
    }

    public class Last
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
        public int? linked_id_item { get; set; }
        public int? linked_id_noted { get; set; }
        public int? linked_id_placeholder { get; set; }
        public bool placeholder { get; set; }
        public bool equipable { get; set; }
        public bool equipable_by_player { get; set; }
        public bool equipable_weapon { get; set; }
        public int cost { get; set; }
        public int? lowalch { get; set; }
        public int? highalch { get; set; }
        public float weight { get; set; }
        public int? buy_limit { get; set; }
        public bool quest_item { get; set; }
        public string release_date { get; set; }
        public bool duplicate { get; set; }
        public string examine { get; set; }
        public string icon { get; set; }
        public string wiki_name { get; set; }
        public string wiki_url { get; set; }
        public object equipment { get; set; }
        public object weapon { get; set; }
        public string _created { get; set; }
        public string _updated { get; set; }
        public string _etag { get; set; }
        public _Links1 _links { get; set; }
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


    public class Items
    {
        private static _Items _download_serialized_json_data<_Items>(string url) where _Items : new()
        {
            using (var w = new WebClient())
            {
                var json_data = string.Empty;
                // attempt to download JSON data as a string
                try
                {
                    json_data = w.DownloadString(url);
                }
                catch (Exception) { }
                // if string with JSON data is not empty, deserialize it to class and return its instance 
                return !string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<_Items>(json_data) : new _Items();
            }
        }
    }
    
}
