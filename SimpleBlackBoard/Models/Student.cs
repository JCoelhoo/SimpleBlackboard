using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SimpleBlackBoard.Models
{
    public class Student
    {
        public int Student_ID { get; set; }
        public string Name { get; set; }
        public bool Uploaded { get; set; }
        public int Role_ID { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }

    }
    public class StudentContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
    }
}