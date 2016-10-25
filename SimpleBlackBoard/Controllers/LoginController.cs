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
            string errorMessage;
            StudentManager.CheckExistingEmail(login.Email, out errorMessage);
            errorMessage = "aa";
            if(!errorMessage.Equals("") || errorMessage!=null)
            {
                ViewBag.Error = errorMessage;
                return RedirectToAction("Login", new { errorMessage = errorMessage });
            } 
            return RedirectToAction("Home");
        }

        // 
        // GET: /HelloWorld/Welcome/ 
        [Route("Welcome")]
        public string Welcome()
        {
            return "This is the Welcome action method...";
        }
    }
}