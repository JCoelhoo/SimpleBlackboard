using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using SimpleBlackBoard.Models;

namespace SimpleBlackBoard.Business_Layer
{
    public class CommonManager
    {
        public static Boolean CheckExistingEmail(String email, out string errorMessage)
        {
            try
            {

                using (var context = new SchoolContext())
                {
                    var studentResultSet = from student in context.Students
                                            select student.Email;
                    
                    var lecturerResultSet = from lecturer in context.Lecturers
                                            select lecturer.Email;

                    var allResultSets = (studentResultSet.Concat(lecturerResultSet)).ToList();
                    foreach(var Email in allResultSets)
                    {
                        if(Email.Equals(email))
                        {
                            errorMessage = "Email Already Exists";
                            return true; 
                        }
                    }
                    errorMessage = "";
                    return false;
                }
            }
            catch (Exception e)
            {
                errorMessage = "Database Error When Retrieving Email!";
                return false; //db error
            }
        }
    }
}