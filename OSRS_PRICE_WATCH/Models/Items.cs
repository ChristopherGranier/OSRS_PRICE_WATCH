using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;

namespace OSRS_PRICE_WATCH.Models
{
    //Item Class. This class will store the information gathered from the API
    //and format it according to the user's selection
    public class Items
    {
        public string ItemID { get; set; }
        [Required(ErrorMessage = "Enter an item name")]
        public string Name { get; set; }
        public int Price { get; set; }
        public int HighAlchPrice { get; set; }


    }
}
