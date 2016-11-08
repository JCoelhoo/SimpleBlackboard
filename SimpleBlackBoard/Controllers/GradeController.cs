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

            ViewBag.Student_ID = id;

            return View();
        }

        [Route("Grade")]
        [HttpPost]
        public ActionResult Grade(Assignment partialAssignment, int id)
        {
            var assignment = AssignmentManager.GetAssignmentByStudentId(id);
            string errorMessage;

            assignment.Feedback = partialAssignment.Feedback;
            assignment.Grade = partialAssignment.Grade;

            AssignmentManager.GradeAssignment((int)Session["Id"],
                assignment,
                out errorMessage);

            return RedirectToAction("Manager", "Dashboard");
        }
    }
}