using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OSRS_PRICE_WATCH.Models
{
    public class Administrator : AccountInformation
    {
        public bool IsAdmin { get; set; }

        public static void UpdateUserInfo()
        {

        }
    }
}
