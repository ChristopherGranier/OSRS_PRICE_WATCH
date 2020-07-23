using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace OSRS_PRICE_WATCH.Controllers
{
    public class AccountController : Controller
    {
        public ViewResult Login() => View();

        public ViewResult Signup() => View();
    }
}