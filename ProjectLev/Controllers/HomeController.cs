using ProjectLev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectLev.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index(string user)
        {
             
            return View();
        }

        [HttpPost]
        public ActionResult createUser(string userId, string userEmail, string userFullname, byte userPrivileges, string userPassword)
        {
            try
            {
                using (var ctx = new arivanLevEntities())
                {

                    TblUser newUser = ctx.TblUser.Create();
                   
                    newUser.personID = userId;
                    newUser.email = userEmail;
                    newUser.fullName = userFullname;
                    newUser.privileges = userPrivileges;
                    newUser.password = userPassword;


                    ctx.TblUser.Add(newUser);
                    ctx.SaveChanges();
                    return Json("user created!");

                }
            }
            catch (Exception ex)
            {
                return Json(ex.InnerException.InnerException.ToString());
            }

        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}