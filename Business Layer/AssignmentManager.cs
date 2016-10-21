using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using SimpleBlackBoard.Models;
using System.Web;
using System.IO;

namespace Business_Layer
{
    public class AssignmentManager
    {
        //GradeAssignment(student_ID, assignment_ID) Post
        public static void GradeAssignment(int Student_ID, Assignment Assignment, out string errorMessage)
        {
            try
            {
                using (var context = new AssignmentContext())
                {
                    var editAssingment = (from assignment in context.Assingments
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

        //UploadAssignment(student_ID,assignment_ID,lecturer_ID) Post
        public static Boolean UploadAssignment(Assignment assignment, HttpPostedFileBase file, out string errorMessage)
        {
            try
            {
                AddAssigment(assignment, out errorMessage);

                if (Path.GetExtension(file.FileName) != "hmtl")
                {
                    errorMessage = "Invalid file type";
                    return false;
                }

                if (file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(String.Format("{1}.html", assignment.Student_ID));
                    var path = "./Assignments/" + fileName;
                    file.SaveAs(path);
                }

                StudentManager.UpdateUploaded(assignment, out errorMessage);
                errorMessage = "";
                return true;
            }
            catch (Exception e)
            {
                errorMessage = "Database Problem";
                return false;
            }
        }
        
        //GetAssesment(assignment_ID) Get to view grade and feedback
        public static Assignment GetAssesmentById(int Assignment_ID)
        {
            try
            {
                Assignment assignmentReturn = new Assignment();
                using (var context = new AssignmentContext())
                {
                    var assignmentResult = (from assignment in context.Assingments
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
            catch
            {
                return null;
            }
        }

        public static void AddAssigment(Assignment assignment, out string errorMessage)
        {
            try
            {
                using (var context = new AssignmentContext())
                {
                    context.Assingments.Add(assignment);
                    context.SaveChanges();
                    errorMessage = "";
                }
            }
            catch (Exception)
            {
                errorMessage = "Database Error";
            }
        }
    }
}
