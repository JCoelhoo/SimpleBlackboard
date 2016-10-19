using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleBlackBoard.Models;
using System.Data.Entity;

namespace UnitTester
{
    public class mainTester
    {
        public static void main(String[] args)
        {
            using (var studentContext = new StudentContext())
            {
                var query = from student in studentContext.Students
                            orderby student.Student_ID
                            select student;
                foreach (var student in query)
                {
                    Console.WriteLine(student.Name+" "+student.Email+" "+student.Student_ID+" "+student.Uploaded);
                }
                Console.Read();
            }
        }
    }
}
