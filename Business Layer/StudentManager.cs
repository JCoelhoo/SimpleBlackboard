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
        private StudentContext StudentContext;  //table
        private DbSet<Student> Students; //for adding

        public static List<Student> getStudentsByLecturerId(int Lecturer_ID)
        { 
            return null;
        }

        public static void AddStudent() //for registration
        {
            //add try catch in controller
        }

        public static Student getStudentById(int Student_ID)
        {
            return null;
        }


    }
}
