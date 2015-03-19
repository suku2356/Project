using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Introconduit1.Models;

namespace Introconduit1.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LogIn(Introconduit1.Models.UserModel user)
        {
            if (ModelState.IsValid == false)
            {
                if (IsValid(user.Email, user.Password))
                {
                    FormsAuthentication.SetAuthCookie(user.Email, false);
                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    ModelState.AddModelError("", "Login data is incorrect");
                }
            }
            return View(user);

        }

        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(Introconduit1.Models.UserModel user)
        {
            if (ModelState.IsValid == false)
            {
                using (var db = new MainDBContext())
                {
                    var crypto = new SimpleCrypto.PBKDF2();

                    var encrpPass = crypto.Compute(user.Password);
                    
                    var sysUser = db.SystemUsers.Create();
                    
                    sysUser.Email = user.Email;
                    sysUser.Password = encrpPass;
                    sysUser.PasswordSalt = crypto.Salt;
                    sysUser.UserId = Guid.NewGuid();

                    db.SystemUsers.Add(sysUser);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ModelState.AddModelError("", "Login data is incorrect");
            }
            return View(user);

        }
        public ActionResult LogOut() 
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index","Home");
        }
        
        
        private bool IsValid(string Email, string Password)
        {
            var crypto = new SimpleCrypto.PBKDF2();
            bool IsValid = false;
            using (var db = new MainDBContext())
            {
                var user = db.SystemUsers.FirstOrDefault(u => u.Email == Email);
                if (user != null)
                {
                    if (user.Password == crypto.Compute(Password, user.PasswordSalt))
                    {
                        IsValid = true;
                    }


                }
                return IsValid;
            }





        }
    }
}
