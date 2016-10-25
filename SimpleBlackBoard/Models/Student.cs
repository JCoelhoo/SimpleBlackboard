using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleBlackBoard.Models
{
    [Table("Student")]
    public class Student
    {
        [Key]
        [Column("Student_ID")]
        public int Student_ID { get; set; }
        [Column("Uploaded")]
        public bool Uploaded { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        [Column("Email")]
        public string Email { get; set; }
        [Column("Password")]
        public string Password { get; set; }
        
        [Column("Lecturer_ID")]
        public int Lecturer_ID { get; set; }

    }
    public class StudentContext : DbContext
    {
        public StudentContext() : base("name=SimpleBlackBoard") { }
        public DbSet<Student> Students { get; set; }
    }
}