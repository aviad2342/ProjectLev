using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;
using ProjectLev.Models;

namespace ProjectLev.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        public ActionResult Index()
        {
            return View();
        }

        [Route("profile/{id}")]
        public ActionResult showUserProfileById(string id)
        {
            var currentUserId = Session["logUserId"];

            var urlUserId = id;
           
            if(currentUserId != null)
            {
                if (currentUserId.Equals(urlUserId))
                {
                    try
                    {
                        using (var ctx = new arivanLevEntities())
                        {


                            var currentUser = UserModel.getUserById(currentUserId.ToString());

                          
                           
                            return View("Index",currentUser);
                        }
                    }
                    catch (Exception ex)
                    {
                        return Json(ex.InnerException.InnerException.ToString());
                    }
                   
                }
           }
         
            return RedirectToAction("Index", "Login");

        }
    }
}