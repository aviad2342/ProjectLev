using ProjectLev.Models;
using System.Linq;
using System.Web.Helpers;
using System.Web.Mvc;

namespace ProjectLev.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();

        }




        [HttpPost]
        public ActionResult formLogin(string personId, string password)
        {

            UserModel logInUser = new UserModel();
            logInUser = UserModel.userLogIn(personId, password);

            if (logInUser != null)
            {
                Session["logUserId"] = logInUser.personID;
                Session["logUserName"] = logInUser.fullName;
                Session["logUserMail"] = logInUser.email;
                Session["logUserPrivilege"] = logInUser.privileges;

                return Json(Url.Action("Index", "Home", new { user = personId }));
            }
            else
            {
                return Json(Url.Action("Index", "Login", new { user = personId }));
            }
        }

    }
}