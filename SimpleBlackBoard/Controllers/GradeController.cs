using SimpleBlackBoard.Business_Layer;
using SimpleBlackBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleBlackBoard.Controllers
{
    public class GradeController : Controller
    {
        // GET: Grade
        [Route("Grade/{id:int}")]
        [HttpGet]
        public ActionResult Grade(int id)
        {
            if (Session["IsStudent"] == null)
                return RedirectToAction("Login", "Login");

            var assignment = AssignmentManager.GetAssignmentByStudentId(id);

            ViewBag.Assignment = assignment;

            ViewBag.Title = "Grade";

            return View();
        }

        [Route("Grade")]
        [HttpPost]
        public ActionResult Grade(Assignment assignment)
        {
            assignment = assignment;
            return null;
        }
    }
}