using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using SimpleBlackBoard.Models;

namespace Business_Layer
{
    public class AssignmentManager
    {
        private AssignmentContext AssignmentContext;  //table
        private DbSet<Assignment> Assignments; //for adding

        //GradeAssignment(student_ID, assignment_ID) Post
        public static void GradeAssignment(int Student_ID, int Assignment_ID)
        {

        }

        //GetAssignment(student_ID,assignment_ID) Get file
        public static void getAssignment(int Student_ID, int Assignment_ID)
        {
            
        }

        //UploadAssignment(student_ID,assignment_ID,lecturer_ID) Post
        public static void uploadAssignment(int Student_ID, int Assignment_ID, int Lecturer_ID)
        {
            
        }
        
        //AddAssignment(student_ID,lecturer_ID) called from studentmanager Post
        public static void AddAssignment(int Student_ID,int Lecturer_ID)
        {
            
        }
        //GetAssesment(assignment_ID) Get to view grade and feedback
        public static Assignment GetAssesment(int Assignment_ID)
        {
            return null;
        }
    }
}
