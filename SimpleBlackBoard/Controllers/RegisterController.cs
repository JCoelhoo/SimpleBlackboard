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
        [Route("LecturerRegister")]
        [HttpGet]
        public ActionResult LecturerRegister()
        {
            return View();
        }

        [Route("StudentRegister")]
        [HttpGet]
        public ActionResult StudentRegister()
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
                return RedirectToAction("LecturerRegister");
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
                
                return RedirectToAction("StudentRegister");
            }
            return RedirectToAction("HomeS");
        }
    }
}