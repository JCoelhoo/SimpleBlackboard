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
    [Table("Lecturer")]
    public class Lecturer
    {
        [Key]
        [Column("Lecturer_ID")]
        [HiddenInput(DisplayValue = false)]
        public int Lecturer_ID { get; set; }
        [Column("Name")]
        public String Name { get; set; }
        [Column("Email")]
        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }
        [DataType(DataType.Password)]
        [Column("Password")]
        public String Password { get; set; }

    }
    public class LecturerContext : DbContext
    {
        public LecturerContext() : base("name=SimpleBlackBoard") { }
        public DbSet<Lecturer> Lecturers { get; set; }
    }
}