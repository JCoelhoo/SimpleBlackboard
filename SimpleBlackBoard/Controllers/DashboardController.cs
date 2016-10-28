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
            ViewBag.Uploaded = AssignmentManager.CheckUploaded(1, out errorMessage);
            ViewBag.Evaluated = AssignmentManager.CheckEvaluated(1, out errorMessage);
            return View();
        }

        [Route("Dashboard/Lecturer")]
        [HttpGet]
        public ActionResult Lecturer()
        {
            ViewBag.Assignments = new ArrayList { new Assignment { Asst_ID = 1, Lecturer_ID = 0, Student_ID = 2 }, new Assignment { Asst_ID = 1, Lecturer_ID = 0, Student_ID = 54 } };
            return View();
        }
    }
}