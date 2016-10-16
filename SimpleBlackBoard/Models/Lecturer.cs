using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SimpleBlackBoard.Models
{
    public class Lecturer
    {
        public int Lecturer_ID { get; set; }
        public String Name { get; set; }
        public int Role_ID { get; set; }   
        public String Email { get; set; }
        public String Password { get; set; }

    }
    public class LecturerContext : DbContext
    {
        public DbSet<Lecturer> Lecturers { get; set; }
    }
}