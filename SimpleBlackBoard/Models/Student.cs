using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using System.ComponentModel;

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
        [Required]
        public bool Uploaded { get; set; }
        [Column("Name")]
        [MaxLength(50)]
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
        [Column("Email")]
        [MaxLength(50)]
        [DataType(DataType.EmailAddress)]
        [Required(AllowEmptyStrings = false)]
        public string Email { get; set; }
        [Column("Password")]
        [MaxLength(50)]
        [DataType(DataType.Password)]
        [Required(AllowEmptyStrings = false)]
        public string Password { get; set; }
        [HiddenInput(DisplayValue = false)]
        [Column("Lecturer_ID")]
        [ForeignKey("Lecturer")]
        public virtual int? Lecturer_ID { get; set; }

        [HiddenInput(DisplayValue = false)]
        [Column("Role_ID")]
        [Required]
        [DefaultValue("false")]
        public bool Role_ID { get; set; } = false; 


        public virtual Lecturer Lecturer { get; set; }
    }
  
}