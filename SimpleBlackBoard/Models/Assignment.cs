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
        [Required]
        [Column("Asst_ID")]
        public int Asst_ID { get; set; }
        
        [ForeignKey("Student")]
        [Column("Student_ID")]
        public virtual int? Student_ID { get; set; }
        
        [Column("Lecturer_ID")]
        [ForeignKey("Lecturer")]
        public virtual int? Lecturer_ID { get; set; }
        [Column("Grade")]
        public double? Grade { get; set; }
        [Column("Feedback")]
        [MaxLength(200)]
        public String Feedback { get; set; }
        [Required]
        [Column("Status_ID")]
        public int Status_ID { get; set; }

        public virtual Student Student { get; set; }
        public virtual Lecturer Lecturer { get; set; }
    }
   
}