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
        public ActionResult Grade(int id)
        {
            if (Session["IsStudent"] == null)
                return View("Login");

            return View(new Assignment { Asst_ID = 1, Lecturer_ID = 0, Student_ID = 2 }); //AssignmentManager.GetAssignmentGradeById(id));
        }
    }
}