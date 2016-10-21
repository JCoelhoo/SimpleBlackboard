using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using SimpleBlackBoard.Models;

namespace Business_Layer
{
    public class StudentManager
    {
        //private BlackBoardContext BlackBoardContext;  //table
        //private DbSet<Student> Students; //for adding

        public static List<Student> getStudentsByLecturerId(int Lecturer_id)
        {
            try
            {
                List<Student> students = new List<Student>();
                using (var context = new StudentContext())
                {
                    var studentListResult = (from student in context.Students
                                              orderby student.Student_ID
                                              where student.Lecturer_ID == Lecturer_id
                                              select student).ToList();
                   if(studentListResult !=null )
                    {
                        foreach(var student in studentListResult)
                        {
                            Student s = new Student();
                            s.Email = student.Email;
                            s.Password = student.Password;
                            s.Lecturer_ID = student.Lecturer_ID;
                            s.Name = student.Name;
                            s.Student_ID = student.Student_ID;
                            s.Uploaded = student.Uploaded;
                            students.Add(s);
                        }
                    }
                    return students;
                }
            }
            catch(Exception e)
            {
                //log error 
                Console.Write(e);
                return null;
            }
            
        }

        public static Boolean AddStudent(Student studentObj, out string errorMessage) //for registration
        {
            //Do Validation in controller
            Boolean checkEmail = checkExistingEmail(studentObj.Email,out errorMessage);
            if (checkEmail == false)
            {
                try
                {
                    int[] allLecturerIds = LecturerManager.AllLecturerIds(); //get all Lecturer Id's in array
                    int selectedLecturerID = AssignRandomLecturer(allLecturerIds); //call helper method to randomly assign a lecturer to the student
                    using (var context = new StudentContext())
                    {
                        studentObj.Lecturer_ID = selectedLecturerID; //assign random lecturer
                        context.Students.Add(studentObj);
                        context.SaveChanges();
                        errorMessage = "";
                        return true; //Worked
                    }
                }
                catch (Exception e)
                {
                    errorMessage = "Database Problem";
                    return false;
                }
            }
            else
            {
                //Email Exists
                return false; // didnt work
            }
        }

        //helper method to randomly assign a lecturer Id to student 
        public static int AssignRandomLecturer(int[] lecturerIDArray)
        {
            int lecturerID_size = lecturerIDArray.Length; //size of array (aka number of ids)
            Random rnd = new Random();
            int lecturerID_selected = rnd.Next(1, lecturerID_size+1); //generate random between min and max inclusive
            return lecturerIDArray[lecturerID_selected]; //return random lec id at location of rndm
        }
        public static Student getStudentById(int Student_id)
        {
            try
            {
                Student returnedStudent = new Student();
                using (var context = new StudentContext())
                {
                    var studentResult = (from student in context.Students
                                     where student.Student_ID == Student_id
                                     select student).FirstOrDefault();
                    if(studentResult !=null)
                    {
                        returnedStudent.Email = studentResult.Email;
                        returnedStudent.Name = studentResult.Name;
                        returnedStudent.Student_ID = studentResult.Student_ID;
                        returnedStudent.Uploaded = studentResult.Uploaded;
                        returnedStudent.Password = studentResult.Password;
                        returnedStudent.Lecturer_ID = studentResult.Lecturer_ID;
                        
                    }
                    return returnedStudent;
                }
            }
            catch(Exception e)
            {
                return null;
            }
        }

        public static Boolean checkExistingEmail(String email,out string errorMessage)
        {
            try
            {
                
                using (var context = new StudentContext())
                {
                    var studentResult = (from student in context.Students
                                         where student.Email == email
                                         select student).FirstOrDefault();
                    if (studentResult != null)
                    {
                        errorMessage = "Email already Exists!";
                        return true; //email exists
                    }
                    errorMessage = "";
                    return false; //email doesnt exist
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

