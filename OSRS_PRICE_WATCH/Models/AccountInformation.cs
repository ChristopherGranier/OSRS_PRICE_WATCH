using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OSRS_PRICE_WATCH.Models
{
    //Account information class. This class stores information used
    //to retrieve info from the SQL Database. It also contains methods
    //that lets the user interact with the website by retrieving information
    //from the API.
    public class AccountInformation
    {
        public string UserID { get; set; }
        public string Password { get; set; }
        public string LoginStatus { get; set; }
        public DateTime RegisterDate { get; set; }
        public string ItemFavorites { get; set; }

        public static void Authenticate()
        {

        }

        public static void LookupItem()
        {

        }

        public static void FavoriteItem()
        {

        }

    }
}
