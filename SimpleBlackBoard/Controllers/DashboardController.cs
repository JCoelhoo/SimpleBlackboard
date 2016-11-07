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
        [Route("Dashboard")]
        [HttpGet]
        public ActionResult Manager()
        {
            string errorMessage;
            //id from session?
            if (Session["IsStudent"] == null)
                return View("Login");

            if ((bool)Session["IsStudent"])
            {
                ViewBag.Uploaded = AssignmentManager.CheckUploaded(2, out errorMessage);
                ViewBag.Evaluated = AssignmentManager.CheckGraded(2, out errorMessage);
                return View("Student");
            }
            else
            {
                ViewBag.Assignments = AssignmentManager.getAssignmentsByLecturerId(1, out errorMessage);
                return View("Lecturer");
            }
            
        }
    }
}