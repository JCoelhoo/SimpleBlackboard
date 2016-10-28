using SimpleBlackBoard.Business_Layer;
using SimpleBlackBoard.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleBlackBoard.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        [Route("Dashboard/Student")]
        [HttpGet]
        public ActionResult Student()
        {
            string errorMessage;
            //id from session?
            ViewBag.Uploaded = AssignmentManager.CheckUploaded(2, out errorMessage);
            ViewBag.Evaluated = AssignmentManager.CheckGraded(2, out errorMessage);
            return View();
        }

        [Route("Dashboard/Lecturer")]
        [HttpGet]
        public ActionResult Lecturer()
        {
            string errorMessage;
            ViewBag.Assignments = AssignmentManager.getAssignmentsByLecturerId(1, out errorMessage);
            return View();
        }
    }
}