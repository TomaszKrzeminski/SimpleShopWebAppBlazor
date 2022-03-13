using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SimpleShopWebApp.Models;

namespace SimpleShopWebApp.Controllers
{
    //[Authorize]
   
    public class AdminController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        public AdminController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }



        [Authorize(Roles = "Administrator")]
        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> AddProduct()
        {
            IdentityUser user=await  _userManager.GetUserAsync(HttpContext.User);
            var role =await _userManager.GetRolesAsync(user);

            return View();
        }


    }
}
