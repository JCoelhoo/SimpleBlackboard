using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace SimpleBlackBoard.Models
{
    [Table("Student")]
    public class Student
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        [Column("Student_ID")]
        public int Student_ID { get; set; }
        [HiddenInput(DisplayValue = false)]
        [Column("Uploaded")]
        public bool Uploaded { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        [Column("Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Column("Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [HiddenInput(DisplayValue = false)]
        [Column("Lecturer_ID")]
        public int Lecturer_ID { get; set; }

    }
    public class StudentContext : DbContext
    {
        public StudentContext() : base("name=SimpleBlackBoard") { }
        public DbSet<Student> Students { get; set; }
    }
}