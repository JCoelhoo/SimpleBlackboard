using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleBlackBoard.Models;
using System.Data.Entity;

namespace UnitTester
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //using (var context = new StudentContext())
            //{
            //    bool test = context.Database.Exists();
            //    Console.Write(test);
            //    Console.Read();
            //}

            var newStudent = new Student();
            newStudent.Name = "testInsert";
            newStudent.Email = "lala@lala.com";
            newStudent.Password = "231231";
            newStudent.Uploaded = null;


            using (var context = new StudentContext())
            {
                List<Student> students = (from student in context.Students
                                          orderby student.Student_ID
                                          select student).ToList();
                Console.Write(students.Count.ToString());
                foreach (var student in students)
                {
                    Console.WriteLine(student.Name + " " + student.Student_ID + " " + student.Email + " " + student.Uploaded);
                    Console.WriteLine();
                }
                Console.Read();


                //////context.Students.Add(newStudent);
                //////context.SaveChanges();

                //////var studentResult = (from student in context.Students
                //////                     where student.Student_ID == 5
                //////                     select student).FirstOrDefault();

                //////Console.Write(studentResult.Student_ID);
                //////Console.Read();
            }
        }
    }
}


