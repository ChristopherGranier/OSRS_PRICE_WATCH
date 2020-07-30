using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OSRS_PRICE_WATCH.Models
{
    public class FavoriteModel
    {
        [Key]
        public string Username { get; set; }
        public string ItemID { get; set; }
    }
}
