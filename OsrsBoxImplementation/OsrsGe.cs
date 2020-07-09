using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text;
using static OsrsBoxImplementation.OsrsGe;

namespace OsrsBoxImplementation
{
    public class OsrsGe
    {

        public class RootobjectOsrsGe
        {
            [Required(ErrorMessage ="Please enter a name")]
            public Item item { get; set; }
        }

        public class Item
        {
            public string icon { get; set; }
            public string icon_large { get; set; }
            public int id { get; set; }
            public string type { get; set; }
            public string typeIcon { get; set; }
            [Required(ErrorMessage = "Please enter a name")]
            public string name { get; set; }
            public string description { get; set; }
            public Current current { get; set; }
            public Today today { get; set; }
            public string members { get; set; }
            public Day30 day30 { get; set; }
            public Day90 day90 { get; set; }
            public Day180 day180 { get; set; }
        }

        public class Current
        {
            public string trend { get; set; }
            public string price { get; set; }
        }

        public class Today
        {
            public string trend { get; set; }
            public string price { get; set; }
        }

        public class Day30
        {
            public string trend { get; set; }
            public string change { get; set; }
        }

        public class Day90
        {
            public string trend { get; set; }
            public string change { get; set; }
        }

        public class Day180
        {
            public string trend { get; set; }
            public string change { get; set; }
        }

    }

    public class DownloadedItemOsrsGe
    {

        public static RootobjectOsrsGe Download_serialized_json_data(string url)
        {
            using (var webClient = new WebClient())
            {
                string json_data = webClient.DownloadString(url);
                RootobjectOsrsGe obj = new RootobjectOsrsGe();
                obj = JsonConvert.DeserializeObject<RootobjectOsrsGe>(json_data);

                return obj;

            }
        }
    }
}
