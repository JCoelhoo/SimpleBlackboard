using SimpleBlackBoard.Business_Layer;
using SimpleBlackBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleBlackBoard.Controllers
{
    public class RegisterController : Controller
    {
        [Route("Register")]
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        // GET: Register
        [Route("LecturerRegister")]
        [HttpPost]
        public ActionResult LecturerRegister(Lecturer lec)
        {
            string errorMessage;
            if(!LecturerManager.AddLecturer(lec, out errorMessage))
            {
                return RedirectToAction("Register");
            }
            return RedirectToAction("HomeL");
        }

        [Route("StudentRegister")]
        [HttpPost]
        public ActionResult StudentRegister(Student stu)
        {
            string errorMessage;
            if (!StudentManager.AddStudent(stu, out errorMessage))
            {
                
                return RedirectToAction("Register");
            }
            return RedirectToAction("HomeS");
        }
    }
}