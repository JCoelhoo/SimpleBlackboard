using SimpleBlackBoard.Business_Layer;
using SimpleBlackBoard.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SimpleBlackBoard
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //AreaRegistration.RegisterAllAreas();
            //RouteConfig.RegisterRoutes(RouteTable.Routes);
            RouteTable.Routes.MapMvcAttributeRoutes();
            string errorMessage;
            LecturerManager.AddLecturer(new Lecturer { Name = "Dr. John", Email = "j@g.com", Password = "johnny"}, out errorMessage);
            //LecturerManager.AddLecturer(new Lecturer { Name = "Dr. Peter", Email = "p@g.com", Password = "peter"}, out errorMessage);
            //LecturerManager.AddLecturer(new Lecturer { Name = "Dr. Sarah", Email = "s@g.com", Password = "sarah"}, out errorMessage);
            StudentManager.AddStudent(new Student { Name = "Mary", Email = "m@g.com", Password = "mary" }, out errorMessage);
            StudentManager.AddStudent(new Student { Name = "Nath", Email = "n@g.com", Password = "nath" }, out errorMessage);
            StudentManager.AddStudent(new Student { Name = "Vanessa", Email = "v@g.com", Password = "vanessa" }, out errorMessage);
            StudentManager.AddStudent(new Student { Name = "Andre", Email = "a@g.com", Password = "andre" }, out errorMessage);
            StudentManager.AddStudent(new Student { Name = "Bernard", Email = "b@g.com", Password = "bernard" }, out errorMessage);
            //Database.SetInitializer<SchoolContext>(null);
        }
    }
}
