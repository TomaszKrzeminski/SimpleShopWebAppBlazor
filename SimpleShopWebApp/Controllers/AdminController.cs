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
    [Authorize]
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        public AdminController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }



        
        public IActionResult AdminPanel()
        {
            return View();
        }


        public async Task<IActionResult> AddProduct()
        {

            string Role = "";

            try
            {
             IdentityUser user =await  _userManager.GetUserAsync(HttpContext.User);
            var role =await _userManager.GetRolesAsync(user);

                Role = role[0].ToString();

            }
            catch(Exception ex)
            {

            }

           


            if( Role=="Administrator")                  
            {
 return View();
            }
            else
            {
                return View("ErrorText","Nie masz uprawnień Administratora");
            }

           
        }


        public async Task<IActionResult>  RemoveProduct()
        {
            return View();
        }

        public async Task<IActionResult> BlockUser()
        {
            return View();

        }

    }
}
