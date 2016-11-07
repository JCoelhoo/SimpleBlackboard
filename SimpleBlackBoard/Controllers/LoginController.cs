using SimpleBlackBoard.Business_Layer;
using SimpleBlackBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            //if(LecturerManager.Login()){
                Session["IsStudent"] = false;
                Session["Email"] = login.Email;
                return RedirectToAction("Manager", "Dashboard");
            //} else (Student.Login()) 
                Session["IsStudent"] = true;
                Session["Email"] = login.Email;
                return RedirectToAction("Manager", "Dashboard");
            //}

            ViewBag.Error = errorMessage;
            return RedirectToAction("Login", new { errorMessage = errorMessage });
        }
    }
}