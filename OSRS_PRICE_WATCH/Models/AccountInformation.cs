using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OSRS_PRICE_WATCH.Models
{
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
