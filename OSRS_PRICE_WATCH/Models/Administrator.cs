using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OSRS_PRICE_WATCH.Models
{
    //Administrator Class. This class inherits the AccountInformation class. 
    //This class signifies a user as an admin and allows admins to update a 
    //user's password
    public class Administrator : AccountInformation
    {
        public bool IsAdmin { get; set; }

        public static void UpdateUserInfo()
        {

        }
    }
}
