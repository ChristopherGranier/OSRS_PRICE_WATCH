using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OSRS_PRICE_WATCH.Models
{
    //Cart Class. This class contains information about the user's
    //cart and includes methods to edit the cart or purchase items
    public class Cart
    {
        public List<Items> items = new List<Items>();
        public int TotalPrice { get; set; }
        public int NumItems { get; set; }

        public static void AddItem()
        {

        }

        public static void DeleteItem()
        {

        }

        public static void Purchase()
        {

        }

        public int GetTotal()
        {

        }
    }
}
