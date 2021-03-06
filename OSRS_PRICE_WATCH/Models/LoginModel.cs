﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OSRS_PRICE_WATCH.Models
{
    public class LoginModel
    {
        [Required]
        [MaxLength(15)]
        [UIHint("username")]
        public string Username { get; set; }

        [Required]
        [UIHint("password")]
        public string Password { get; set; }


    }
}
