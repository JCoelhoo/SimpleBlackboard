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
        public enum LoginStatus {Lecturer, Student,DoesntExist,Fail};
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
        public static LoginStatus Login(Login log, out string ErrorMessage)
        {
           try
           {
                using (var context = new SchoolContext())
                {
                    var studentResultSet = from student in context.Students
                                           select new
                                           {
                                               student.Email,
                                               student.Password,
                                               student.Role_ID
                                           };

                    var lecturerResultSet = from lecturer in context.Lecturers
                                            select new
                                            {
                                                lecturer.Email,
                                                lecturer.Password,
                                                lecturer.Role_ID
                                            };

                    var allResultSets = (studentResultSet.Concat(lecturerResultSet)).ToList();
                    foreach (var record in allResultSets)
                    {
                        if (record.Email!=null)
                        {
                            if(record.Email.Equals(log.Email) && record.Password.Equals(log.Password))
                            {
                                if(record.Role_ID == true )
                                {
                                    ErrorMessage = "";
                                    return LoginStatus.Lecturer;
                                }
                                ErrorMessage = "";
                                return LoginStatus.Student;
                            }
                        }
                    }
                    ErrorMessage = "";
                    return LoginStatus.DoesntExist;
                }
           }
           catch(Exception)
           {
                ErrorMessage = "Database Error";
                return LoginStatus.Fail;
            }
        }
    }
}