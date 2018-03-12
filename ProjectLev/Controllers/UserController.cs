using ProjectLev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectLev.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {

            return View();
        }



        public JsonResult GetUsers()
        {
            try
            {
                using (var ctx = new arivanLevEntities())
                {


                    List<TblUser> users = ctx.TblUser.ToList();

                    var dataset = users
                                .Select(x => new UserModel
                                {
                                    personID = x.personID,
                                    fullName = x.fullName,
                                    email = x.email,
                                    privileges = x.privileges,
                                    userAddress = x.userAddress,
                                    profilePic = x.profilePic
                                }).ToList();

                    return Json(dataset, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.InnerException.InnerException.ToString());
            }

        }


        [HttpPost]
        public ActionResult addUser(string personId, string userEmail, string userFullname, byte userPrivileges, string userAddress, string profilePic, string userPassword)
        {
                UserModel newUser = new UserModel();
                newUser.personID = personId;
                newUser.email = userEmail;
                newUser.fullName = userFullname;
                newUser.privileges = userPrivileges;
                newUser.userAddress = userAddress;
                newUser.profilePic = profilePic;
                newUser.password = userPassword;

            if (UserModel.addNewUser(newUser))
            {
                newUser.password = null;
                return Json(newUser);
            }
            else
            {
                return Json("error");
            }

        }


        [HttpPost]
        public ActionResult updateUser(string personId, string userEmail, string userFullname, byte userPrivileges, string userAddress, string profilePic)
        {
            UserModel updateUser = new UserModel();

            updateUser.personID = personId;
            updateUser.email = userEmail;
            updateUser.fullName = userFullname;
            updateUser.privileges = userPrivileges;
            updateUser.userAddress = userAddress;
            updateUser.profilePic = profilePic;

            if (UserModel.updateUser(updateUser))
            {
               // updateUser.password = null;
                return Json(updateUser);
            }
            else
            {
                return Json("error");
            }

        }


        [HttpPost]
        public ActionResult removeUser(string personId)
        {
            if (UserModel.removeUser(personId))
            {
                return Json("success");
            }
            else
            {
                return Json("error");
            }

        }

    }
}