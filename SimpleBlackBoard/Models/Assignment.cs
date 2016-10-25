using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleBlackBoard.Models
{
    [Table("Assignment")]
    public class Assignment
    {
        [Key]
        [Column("Asst_ID")]
        public int Asst_ID { get; set; }
        [Column("Student_ID")]
        public int Student_ID { get; set; }
        [Column("Lecturer_ID")]
        public int Lecturer_ID { get; set; }
        [Column("Grade")]
        public double? Grade { get; set; }
        [Column("Feedback")]
        public String Feedback { get; set; }
        [Column("Status_ID")]
        public int Status_ID { get; set; }
    }
    public class AssignmentContext : DbContext
    {
        public AssignmentContext() : base("name=SimpleBlackBoard") { }
        public DbSet<Assignment> Assingments { get; set; }
    }
}