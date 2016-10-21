using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleBlackBoard.Models;
using System.Data.Entity;
using Business_Layer;
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
            newStudent.Uploaded = null;
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


    }
        
}


