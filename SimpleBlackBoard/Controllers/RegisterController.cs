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
        public ActionResult LecturerRegister(string errorMessage)
        {
            ViewBag.Error = errorMessage;
            return View();
        }

        [Route("StudentRegister")]
        [HttpGet]
        public ActionResult StudentRegister(string errorMessage)
        {
            ViewBag.Error = errorMessage;
            return View();
        }

        [Route("LecturerRegister")]
        [HttpPost]
        public ActionResult LecturerRegister(Lecturer lec)
        {
            string errorMessage = "aa";
            if (!LecturerManager.AddLecturer(lec, out errorMessage))
            {
                ViewBag.Error = errorMessage;
                return RedirectToAction("LecturerRegister", new { errorMessage = errorMessage });
            }
            return RedirectToAction("HomeL");
        }

        [Route("StudentRegister")]
        [HttpPost]
        public ActionResult StudentRegister(Student stu)
        {
            string errorMessage = "aa";
            if (!StudentManager.AddStudent(stu, out errorMessage))
            {
                ViewBag.Error = errorMessage;
                return RedirectToAction("StudentRegister", new { errorMessage = errorMessage });
            }
            return RedirectToAction("HomeS");
        }
    }
}