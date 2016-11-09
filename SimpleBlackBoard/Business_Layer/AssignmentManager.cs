using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using SimpleBlackBoard.Models;
using System.Web;
using System.IO;

namespace SimpleBlackBoard.Business_Layer
{
    public class AssignmentManager
    {
        //GradeAssignment(student_ID, assignment_ID) Post
        public static void GradeAssignment(int Student_ID, Assignment Assignment, out string errorMessage)
        {
            try
            {
                using (var context = new SchoolContext())
                {
                    var editAssingment = (from assignment in context.Assignments
                                          where assignment.Asst_ID == Assignment.Asst_ID
                                          select assignment).FirstOrDefault();
                    editAssingment.Feedback = Assignment.Feedback;
                    editAssingment.Grade = Assignment.Grade;
                    editAssingment.Status_ID = 2;
                    context.SaveChanges();
                    errorMessage = "";
                }
            }
            catch (Exception e)
            {
                errorMessage = "Database Problem";
            }
        }

        public static Boolean UploadAssignment(Assignment assignment, HttpPostedFileBase file, out string errorMessage)
        {
            try
            {
                //after uploading create assignment
                if (AssignmentManager.AddAssigment(assignment, out errorMessage)==true)
                {
                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Content/Assignments")); //create directory if it doesnt exist
                    var fileName = (assignment.Student_ID).ToString() + ".html";
                    var path = Path.Combine(HttpContext.Current.Server.MapPath("~/Content/Assignments"), fileName);
                    file.SaveAs(path);

                    StudentManager.UpdateUploaded(assignment, out errorMessage);
                    errorMessage = "";
                    return true;
                }

                errorMessage = "Assignment Record wasn't Created!";
                return false;
            }
            catch (Exception e)
            {
                errorMessage = "Database Problem";
                return false;
            }
        }
        
        //GetAssesment(assignment_ID) Get to view grade and feedback
        public static Assignment GetAssignmentGradeById(int Assignment_ID)
        {
            try
            {
                Assignment assignmentReturn = new Assignment();
                using (var context = new SchoolContext())
                {
                    var assignmentResult = (from assignment in context.Assignments
                                          where assignment.Asst_ID == Assignment_ID
                                          select assignment).FirstOrDefault();

                    if (assignmentResult != null)
                    {
                        assignmentReturn.Asst_ID = assignmentResult.Asst_ID;
                        assignmentReturn.Feedback = assignmentResult.Feedback;
                        assignmentReturn.Grade = assignmentResult.Grade;
                        assignmentReturn.Lecturer_ID = assignmentResult.Lecturer_ID;
                        assignmentReturn.Student_ID = assignmentResult.Student_ID;
                    }
                    return assignmentReturn;
                }
            }
            catch(Exception e)
            {
                Console.Write(e.Message);
                Console.Read();
                return null;
            }
        }

        public static Boolean AddAssigment(Assignment assignment, out string errorMessage)
        {
            if (CheckUploaded(assignment.Student_ID, out errorMessage) == true)
            {
                return false;
            }
            else
            {
                try
                {
                    using (var context = new SchoolContext())
                    {
                        context.Assignments.Add(assignment);
                        context.SaveChanges();
                        errorMessage = "";
                        return true;
                    }
                }
                catch (Exception e)
                {
                    //errorMessage = e.Message;
                    errorMessage = "Database Error";
                    return false;
                }
            }
        }
        public static Boolean CheckUploaded(int? student_id, out string errorMessage)
        {
            try
            {
                using (var context = new SchoolContext())
                {
                    var check = (from student in context.Students
                                 where student.Student_ID == student_id &&
                                 student.Uploaded == true
                                 select student.Uploaded).Single();

                    if(check == true)
                    {
                        errorMessage = "Student Already Uploaded";
                        return true;
                    }
                    errorMessage = "";
                    return false;
                }
            }
            catch(Exception)
            {
                errorMessage = "DB ERROR";
                return false;
            }
        }
        public static Boolean CheckGraded(int Student_ID,out string errorMessage)
        {
            try
            {
                using (var context = new SchoolContext())
                {
                    var check = (from asst in context.Assignments
                                 where asst.Student_ID == Student_ID  
                                 select asst).FirstOrDefault();

                    if (check.Grade != 0)
                    {
                        errorMessage = "";
                        return true;
                    }
                    errorMessage = "Your assignment isn't yet graded!";
                    return false;
                }
            }
            catch (Exception e)
            {
                errorMessage = "Database Problem "+e.Message;
                return false;
            }
        }
        public static List<Assignment> getAssignmentsByLecturerId(int Lecturer_ID,out string errorMessage)
        {
            try
            {
                using (var context = new SchoolContext())
                {
                    var assignments = (from asst in context.Assignments
                                       orderby asst.Student_ID
                                       where asst.Lecturer_ID == Lecturer_ID
                                       select asst).ToList();
                    if(assignments!=null)
                    {
                        errorMessage = "";
                        return assignments;
                    }
                    errorMessage = "No assignments available for this lecturer";
                    return assignments;
                }
                
            }
            catch (Exception)
            {
                errorMessage = "Database Error";
                return null;
            }
        }

        public static Assignment GetAssignmentByStudentId(int id)
        {
            try
            {
                var returnAssig = new Assignment();
                using (var context = new SchoolContext())
                {
                    var assignment = (from asst in context.Assignments
                                       where asst.Student_ID == id
                                       select asst).FirstOrDefault();

                    if (assignment != null)
                    {
                        returnAssig.Asst_ID = assignment.Asst_ID;
                        returnAssig.Feedback = assignment.Feedback;
                        returnAssig.Grade = assignment.Grade;
                        returnAssig.Lecturer_ID = assignment.Lecturer_ID;
                        returnAssig.Student_ID = assignment.Student_ID;
                        returnAssig.Status_ID = assignment.Status_ID;
                    }
                    return returnAssig;
                }

            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
