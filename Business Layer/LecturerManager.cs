using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using SimpleBlackBoard.Models;

namespace Business_Layer
{
    public class LecturerManager
    {
        private LecturerContext LecturerContext;  //table
        private DbSet<Lecturer> Lecturers; //for adding
        public static void AddLecturer() //for registration
        {
            //add try catch in controller
        }
        public static Lecturer getLecturerById(int Lecturer_ID)
        {
            return null;
        }
        public static List<int> getLecturerIds()
        {
            return null;
        }
        
    }
}
