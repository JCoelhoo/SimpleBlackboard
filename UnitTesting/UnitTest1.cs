﻿using System;
using System.Collections.Generic;
using SimpleBlackBoard.Models;
using SimpleBlackBoard.Business_Layer;
using NUnit.Framework;

namespace UnitTesting
{
    [TestFixture]
    public class SimpleBlackBoard
    {
        [TestCase]
        public static void GetStudentsByLecturer()
        {
            List<Student> test = StudentManager.GetStudentsByLecturerId(1);
            foreach (var t in test)
            {
                Console.WriteLine(t.Student_ID + " " + t.Name);
            }
            Assert.Equals("1", "1");
        }

        [Test]
        public static void getLecturerIdList()
        {
            int[] test = LecturerManager.AllLecturerIds();
            foreach (var lecid in test)
            {
                Console.WriteLine(lecid);
            }

        }

        [Test]
        public static void rndmLec()
        {
            int[] test = new int[] { 12, 14, 15 };
            int rnd = StudentManager.AssignRandomLecturer(test);
            Console.WriteLine(rnd);
        }

        [Test]
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
            Console.Write(b + " " + k);
        }

        [Test]
        public static void getStudentbyID()
        {
            Student test = StudentManager.GetStudentById(6);
            Console.Write(test.Lecturer_ID);
        }

        [Test]
        public static void AddLecturer()
        {
            String k = "";
            Lecturer lec = new Lecturer();
            lec.Email = "lala@lala.com";
            lec.Name = "inserting through code 2";
            lec.Password = "ebola3";
            bool b = LecturerManager.AddLecturer(lec, out k);
            Console.Write(b + " " + k);
        }

        [Test]
        public static void getLecturerByID()
        {
            Lecturer lec = LecturerManager.getLecturerById(2);
            Console.Write(lec.Lecturer_ID + " " + lec.Name);
        }

        [Test]
        public static void AddAssignment()
        {
            String k = "";
            Assignment ass = new Assignment();
            ass.Lecturer_ID = 1;
            ass.Student_ID = 1;
            ass.Status_ID = 1;

            Boolean b = AssignmentManager.AddAssigment(ass, out k);
            Console.Write(b + " " + k);
        }

        [Test]
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
        }

        [Test]
        public static void getAssignmentGradeById()
        {
            Assignment ass = AssignmentManager.GetAssignmentGradeById(1);
            Console.Write(ass.Grade + " " + ass.Feedback);
        }

        [Test]
        public static void checkGraded()
        {
            string k = "";
            Boolean test = AssignmentManager.CheckGraded(1, out k);
            Console.Write(test + " " + k);
        }
    }
}
