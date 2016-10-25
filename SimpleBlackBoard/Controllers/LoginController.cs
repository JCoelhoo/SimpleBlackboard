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
        public ViewResult Login()
        {
            return View();
        }

        [Route("Login")]
        [Route("")]
        [HttpPost]
        public ActionResult Login(Student s)
        {
            /*string errorMessage;
            if (!StudentManager.AddStudent(s, out errorMessage))*/

            return RedirectToAction("student");
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