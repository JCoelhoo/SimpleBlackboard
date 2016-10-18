using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SimpleBlackBoard.Models
{
    public class Assignment
    {
        public int Asst_ID { get; set; }
        public int Student_ID { get; set; }
        public int Lecturer_ID { get; set; }
        public float Grade { get; set; }
        public String Feedback { get; set; }
    }
    public class AssignmentContext : DbContext
    {
        public AssignmentContext() : base() { }
        public DbSet<Assignment> Assingments { get; set; }
    }
}