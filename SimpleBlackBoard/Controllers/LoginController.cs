using SimpleBlackBoard.Business_Layer;
using SimpleBlackBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SimpleBlackBoard.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        //public ActionResult Index()
        //{
        //    return View();
        //}
        [Route("Login")]
        [Route("")]
        [HttpGet]
        public ViewResult Login(string errorMessage)
        {
            ViewBag.Error = errorMessage;
            return View();
        }

        [Route("Login")]
        [Route("")]
        [HttpPost]
        public ActionResult Login(Login login)
        {
            string errorMessage = String.Empty;
            var status = CommonManager.Login(login, out errorMessage);
            if (status == CommonManager.LoginStatus.Lecturer){
                Session["IsStudent"] = false;
                Session["Email"] = login.Email;
                return RedirectToAction("Manager", "Dashboard");
            } else if (status == CommonManager.LoginStatus.Student) { 
                Session["IsStudent"] = true;
                Session["Email"] = login.Email;
                return RedirectToAction("Manager", "Dashboard");
            }

            if (errorMessage != "") ViewBag.Error = errorMessage;
            else if (status == CommonManager.LoginStatus.DoesntExist) ViewBag.Error = "Invalid credentials";

            return RedirectToAction("Login", new { errorMessage = ViewBag.Error });
        }

        [Route("logout")]
        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Login");
        }
    }
}