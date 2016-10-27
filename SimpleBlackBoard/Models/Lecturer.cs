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
        [MaxLength(50)]
        [Required(AllowEmptyStrings = false)]
        public String Name { get; set; }
        [Column("Email")]
        [MaxLength(50)]
        [DataType(DataType.EmailAddress)]
        [Required(AllowEmptyStrings = false)]
        public String Email { get; set; }
        [DataType(DataType.Password)]
        [Column("Password")]
        [MaxLength(50)]
        [Required(AllowEmptyStrings = false)]
        public String Password { get; set; }

    }
   
}