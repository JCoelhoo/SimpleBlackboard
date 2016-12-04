using System;
using System.Collections.Generic;
using SimpleBlackBoard.Models;
using SimpleBlackBoard.Business_Layer;
using NUnit.Framework;

namespace UnitTesting
{
    [TestFixture]
    public class SimpleBlackBoard
    {
        [Test]
        public static void GetStudentsByLecturer()
        {
            List<Student> test = StudentManager.GetStudentsByLecturerId(1);
            Assert.NotNull(test);
            Assert.IsTrue(test.Count == 2);
        }

        [Test]
        public static void getLecturerIdList()
        {
            int[] test = LecturerManager.AllLecturerIds();
            Assert.NotNull(test);
            Assert.IsTrue(test.Length >= 3);
            Assert.NotNull(Array.FindIndex(test, x => x == 1));
        }

        [Test]
        public static void rndmLec()
        {
            int[] test = new int[] { 12, 14, 15 };
            int rnd = StudentManager.AssignRandomLecturer(test);
            Assert.NotNull(rnd);
            Assert.IsTrue(rnd == 12 || rnd == 14 || rnd == 15);
        }

        [Test]
        public static void AddStudent()
        {
            //This Returns Db problem since we cant add a lecture id since its a foreignkey.
            //if we comment this line newStudent.Lecturer_ID = 3; in this case it works
            //try inserting the same user with same email, doesnt work.
            var str = DateTime.Now.ToLongTimeString();
            var k = "";
            var newStudent = new Student();
            newStudent.Name = "testInsert";
            newStudent.Email = "test@email.com" + str; //to allow multiple tests to be done
            newStudent.Password = "231231";
            newStudent.Uploaded = false;
            newStudent.Lecturer_ID = 3;
            Assert.IsTrue(StudentManager.AddStudent(newStudent, out k));

            var student = StudentManager.GetStudentById(StudentManager.GetStudentIdByEmail("test@email.com" + str));
            Assert.IsTrue(student.Name == "testInsert");
            Assert.IsTrue(student.Email == ("test@email.com" + str));
            Assert.IsTrue(CommonManager.Hash("231231") == student.Password);
            Assert.IsTrue(student.Lecturer_ID == 3);
        }

        [Test]
        public static void getStudentbyID()
        {
            Student test = StudentManager.GetStudentById(2);
            Assert.IsTrue(test.Name == "Nath");
            Assert.IsTrue(test.Email == "n@g.com");
            Assert.IsTrue(test.Lecturer_ID == 1);
        }

        [Test]
        public static void AddLecturer()
        {
            String k = "";
            var str = DateTime.Now.ToLongTimeString();
            Lecturer lec = new Lecturer();
            lec.Email = "test@lala.com" + str;
            lec.Name = "lectest";
            lec.Password = "123456";
            bool b = LecturerManager.AddLecturer(lec, out k);

            var student = LecturerManager.getLecturerById(LecturerManager.GetLecturerIdByEmail("test@lala.com" + str));
            Assert.IsTrue(student.Name == "lectest");
            Assert.IsTrue(student.Email == ("test@lala.com" + str));
            Assert.IsTrue(CommonManager.Hash("123456") == student.Password);
        }

        [Test]
        public static void getLecturerByID()
        {
            Lecturer lec = LecturerManager.getLecturerById(2);
            Assert.IsTrue(lec.Name == "Dr. Peter");
            Assert.IsTrue(lec.Email == "p@g.com");
        }

        //this test should be run with specific parameters
        public static void AddAssignment()
        {
            String k = "";
            Assignment ass = new Assignment();
            ass.Lecturer_ID = 1;
            ass.Student_ID = 1;
            ass.Status_ID = 1;

            Assert.IsTrue(AssignmentManager.AddAssigment(ass, out k));
            var assignment = AssignmentManager.GetAssignmentByStudentId(1);

            Assert.IsTrue(assignment.Lecturer_ID == 1);
            Assert.IsTrue(assignment.Student_ID == 1);
            Assert.IsTrue(assignment.Status_ID == 1);
        }

        //this test should be run with specific parameters
        public static void gradeAssignment()
        {
            string k = "";
            string feedback = "This is a unit test";
            var grade = 90;
            Assignment ass = new Assignment();
            ass.Feedback = feedback;
            ass.Grade = grade;
            ass.Asst_ID = 1;
            AssignmentManager.GradeAssignment(1, ass, out k);

            var assig = AssignmentManager.GetAssignmentByStudentId(1);
            Assert.IsTrue(assig.Feedback == feedback);
            Assert.IsTrue(assig.Grade == grade);
        }

        //this test should be run with specific parameters
        public static void getAssignmentGradeById()
        {
            Assignment ass = AssignmentManager.GetAssignmentGradeById(1);
            Assert.NotNull(ass);
            Assert.NotNull(ass.Lecturer_ID);
            Assert.NotNull(ass.Student_ID);
        }

        //this test should be run with specific parameters
        public static void checkGraded()
        {
            string k = "";
            Assert.IsTrue(AssignmentManager.CheckGraded(1, out k));
            var assign = AssignmentManager.GetAssignmentByStudentId(1);

            Assert.IsTrue(assign.Student_ID == 1);
            Assert.NotNull(assign.Feedback);
            Assert.NotNull(assign.Grade);
        }
    }
}
