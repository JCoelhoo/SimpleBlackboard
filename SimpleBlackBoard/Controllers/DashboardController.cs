using SimpleBlackBoard.Business_Layer;
using SimpleBlackBoard.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleBlackBoard.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        [Route("Dashboard")]
        [HttpGet]
        public ActionResult Manager(string message, string errorMessage)
        {
            ViewBag.Message = message;
            ViewBag.Error = errorMessage;

            if (Session["IsStudent"] == null)
                return RedirectToAction("Login", "Login");

            if ((bool)Session["IsStudent"])
            {
                ViewBag.Uploaded = AssignmentManager.CheckUploaded((int) Session["Id"], out errorMessage);
                ViewBag.Evaluated = AssignmentManager.CheckGraded((int)Session["Id"], out errorMessage);
                return View("Student");
            }
            else
            {
                ViewBag.Assignments = AssignmentManager.getAssignmentsByLecturerId((int)Session["Id"], out errorMessage);
                return View("Lecturer");
            }
            
        }

        [Route("Dashboard/Upload")]
        [HttpGet]
        public ActionResult Upload(string errorMessage)
        {
            if (Session["IsStudent"] == null)
                return RedirectToAction("Login", "Login");

            string error;
            if (AssignmentManager.CheckUploaded((int)Session["Id"], out error))
                return RedirectToAction("Manager", "Dashboard");

            ViewBag.Error = errorMessage;
            return View();
        }

        [Route("Dashboard/Upload")]
        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            if (Session["IsStudent"] == null)
                return RedirectToAction("Login", "Login");

            string errorMessage;

            if (file == null || file.ContentLength <= 0)
            {
                errorMessage = "File is empty";
                return RedirectToAction("Upload", new { errorMessage = errorMessage });
            }
            else if( file.ContentType != "text/html" || (file.FileName.Split('.')).Last() != "html")
            {
                errorMessage = "File invalid file type";
                return RedirectToAction("Upload", new { errorMessage = errorMessage });
            }

            var assignment = new Assignment { Student_ID = (int)Session["Id"],
                Status_ID = 0,
                Lecturer_ID = StudentManager.GetLecturerIdByStudentID((int)Session["Id"]) };

            var status = AssignmentManager.UploadAssignment(assignment, file, out errorMessage);
            //error message
            return RedirectToAction("Manager", new { message = "Assignment uploaded successfully", errorMessage = errorMessage });
        }

        [Route("Dashboard/Grade/{id:int}")]
        [HttpGet]
        public ActionResult Grade(int id)
        {
            if (Session["IsStudent"] == null)
                return RedirectToAction("Login", "Login");

            string errorMessage = "";

            var assignments = AssignmentManager.getAssignmentsByLecturerId(id, out errorMessage);

            var v = (from asst in assignments
                     where asst.Student_ID == id
                     select asst).FirstOrDefault();

            if (v == null || errorMessage != "")
                return HttpNotFound();

            if (v.Grade != 0)
                return RedirectToAction("Manager", "Dashboard");

            ViewBag.Student_ID = id;

            return View();
        }

        [Route("Dashboard/Grade")]
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

        [Route("Dashboard/View")]
        [HttpGet]
        public ActionResult ViewGrade()
        {
            if (Session["IsStudent"] == null)
                return RedirectToAction("Login", "Login");

            string errorMessage;

            if (!AssignmentManager.CheckGraded((int)Session["Id"], out errorMessage))
                return RedirectToAction("Manager", "Dashboard");

            var assignment = AssignmentManager.GetAssignmentByStudentId((int) Session["Id"]);

            return View(assignment);
        }
    }
}