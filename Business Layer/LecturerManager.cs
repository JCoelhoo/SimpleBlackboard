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
        public static int[] AllLecturerIds() //returns an array of all lecturer Id's
        {
            try
            {
                
                using (var context = new LecturerContext())
                {
                    var lecturerIDList = (from lecturer in context.Lecturers
                                          orderby lecturer.Lecturer_ID
                                          select lecturer.Lecturer_ID).ToList();
                    if(lecturerIDList!=null)
                    {
                        return lecturerIDList.ToArray();
                    }
                    return lecturerIDList.ToArray();
                }
            }
            catch (Exception e)
            {
                //log error 
                Console.Write(e);
                return null;
            }
        }
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
