using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleBlackBoard.Models;
using System.Data.Entity;
using SimpleBlackBoard.Business_Layer;
namespace UnitTester
{
    public class Program
    {
        public static void Main(string[] args)
        {

            //1.Unit Testing of getStudentsByLecturerId
            //GetStudentsByLecturer();

            //2.Unit Testing of getLecturerList
            //getLecturerIdList();

            //3.Unit testing of random lecturer
            //rndmLec();

            //4.Unit Testing of addStudent
            //AddStudent();

            //5.Unit testing of getStudentById
            //getStudentbyID();

            //6. Add Lecturer
            //AddLecturer();

            //7. Get lecturer by id
            //getLecturerByID();

            //8. Add assignment
            //AddAssignment();

            //9.Grade Assignment
            //gradeAssignment();

            //10. get assignment grade by id
            //getAssignmentGradeById();


            //11. Update Uploaded
            //working

            //12. Upload Assignement
            //do later

            //13 CheckGraded
            checkGraded();
        }
        public static void GetStudentsByLecturer()
        {
            List<Student> test = StudentManager.GetStudentsByLecturerId(1);
            foreach(var t in test)
            {
                Console.WriteLine(t.Student_ID+ " "+t.Name);
            }
            Console.Read();
        }
        public static void getLecturerIdList()
        {
            int[] test = LecturerManager.AllLecturerIds();
            foreach (var lecid in test)
            {
                Console.WriteLine(lecid);
            }

            Console.Read();
        }
        public static void rndmLec()
        {
            int[] test = new int[] { 12, 14 ,15};
            int rnd =  StudentManager.AssignRandomLecturer(test);
            Console.WriteLine(rnd);
            Console.Read();
        }
        public static void AddStudent()
        {
            //This Returns Db problem since we cant add a lecture id since its a foreignkey.
            //if we comment this line newStudent.Lecturer_ID = 3; in this case it works
            //try inserting the same user with same email, doesnt work.
            String k = "";
            var newStudent = new Student();
            newStudent.Name = "testInsert";
            newStudent.Email = "lala@lala.com";
            newStudent.Password = "231231";
            newStudent.Uploaded = false;
            //newStudent.Lecturer_ID = 3;
            bool b = StudentManager.AddStudent(newStudent, out k);
            Console.Write(b +" "+k);
            Console.Read();
        }

        public static void getStudentbyID()
        {
           Student test =  StudentManager.GetStudentById(6);
           Console.Write(test.Lecturer_ID);
           Console.Read();
        }
        public static void AddLecturer()
        {
            String k = "";
            Lecturer lec = new Lecturer();
            lec.Email = "lala@lala.com";
            lec.Name = "inserting through code 2";
            lec.Password = "ebola3";
            bool b = LecturerManager.AddLecturer(lec,out k);
            Console.Write(b + " " + k);
            Console.Read();
        }
        public static void getLecturerByID()
        {
            Lecturer lec = LecturerManager.getLecturerById(2);
            Console.Write(lec.Lecturer_ID+" "+ lec.Name);
            Console.Read();

        }
        public static void AddAssignment()
        {
            String k = "";
            Assignment ass = new Assignment();
            ass.Lecturer_ID = 1;
            ass.Student_ID = 1;
            ass.Status_ID = 1;
            
            Boolean b = AssignmentManager.AddAssigment(ass,out k);
            Console.Write(b + " " + k);
            Console.Read();
        }
        public static void gradeAssignment()
        {
            string k = "";
            string feedback = "This is a unit test";
            float grade = 90;
            Assignment ass = new Assignment();
            ass.Feedback = feedback;
            ass.Grade = grade;
            ass.Asst_ID = 1;
            AssignmentManager.GradeAssignment(1, ass, out k);
            Console.Read();
        }
        public static void getAssignmentGradeById()
        {
            Assignment ass = AssignmentManager.GetAssignmentGradeById(1);
            Console.Write(ass.Grade + " " + ass.Feedback);
            Console.Read();
        }
        public static void checkGraded()
        {
            string k = "";
            Boolean test = AssignmentManager.checkGraded(1, out k);
            Console.Write(test + " " + k);
        }
        


    }
        
}


