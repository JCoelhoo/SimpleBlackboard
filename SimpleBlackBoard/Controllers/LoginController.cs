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
        public ActionResult Login(string errorMessage)
        {
            if (Session["IsStudent"] != null)
                return RedirectToAction("Manager", "Dashboard");

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
                Session["TimeOfCreation"] = DateTime.Now;
                Session["Id"] = LecturerManager.GetLecturerIdByEmail(login.Email);
                if(ModelState.IsValid)
                {
                    return RedirectToAction("Manager", "Dashboard");
                }
                return View();
            } else if (status == CommonManager.LoginStatus.Student) { 
                Session["IsStudent"] = true;
                Session["Email"] = login.Email;
                Session["TimeOfCreation"] = DateTime.Now;
                Session["Id"] = StudentManager.GetStudentIdByEmail(login.Email);
                if (ModelState.IsValid)
                {
                    return RedirectToAction("Manager", "Dashboard");
                }
                return View();
            }

            if (errorMessage != "") ViewBag.Error = errorMessage;
            else if (status == CommonManager.LoginStatus.DoesntExist) ViewBag.Error = "Invalid credentials";

            return RedirectToAction("Login", new { errorMessage = ViewBag.Error });
        }

        [Route("Logout")]
        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Login");
        }
    }
}