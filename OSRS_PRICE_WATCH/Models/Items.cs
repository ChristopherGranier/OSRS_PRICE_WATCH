using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel;

namespace OSRS_PRICE_WATCH.Models
{
    //Item Class. This class will store the information gathered from the API
    //and format it according to the user's selection
    public class Items
    {
        //public string ItemID { get; set; }
        [Required(ErrorMessage ="No")]
        public string Name { get; set; }
       //public int Price { get; set; }
        //public int HighAlchPrice { get; set; }
        //public int ThirtyDay { get; set; }
        //public int SevenDay { get; set; }


        //public static void FormatCategories()
        //{

        //}

        //public static void FilterByPrice()
        //{

        //}

        //public static void FilterByName()
        //{

        //}

        //public static void FilterByThirtyDay()
        //{

        //}

        //public static void FilterBySevenDay()
        //{

        //}

        //public static void FormatGroupItem()
        //{

        //}
    }
}
