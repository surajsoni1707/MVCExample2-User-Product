using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCExample2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCExample2.Controllers
{
    public class UserController : Controller
    {
        UserDAL us = new UserDAL();
        [HttpGet]
        public IActionResult SignUp()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(IFormCollection form)
        {
            User u = new User();
            u.Name = form["Name"].ToString();
            u.Email = form["Email"].ToString();
            u.Password = form["Password"].ToString();
            u.RoleId = 2;
            int res = us.Save(u);
            
            return View();

        }
        [HttpGet]
            public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignIn(IFormCollection form)
        {
            User c = new User();
            c.Email = form["Email"].ToString();
            c.Password = form["Password"].ToString();
            bool res = us.Verify(c);
            if (res == true)
            {
                return RedirectToAction("Index", "Product");
            }
            else
            {
                ViewBag.Message = "Invalid Entry";
                return View();
            }
        }
        public IActionResult Invalid()
        {
            TempData["alertMessage"] = "Invalid Email-id or Password";
            return View();
        }


    }
}
