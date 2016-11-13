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
    [Table("Assignment")]
    public class Assignment
    {
        [Key]
        [Required]
        [Column("Asst_ID")]
        [HiddenInput(DisplayValue = false)]
        public int Asst_ID { get; set; }
        
        [ForeignKey("Student")]
        [Column("Student_ID")]
        [ReadOnly(true)]
        public virtual int? Student_ID { get; set; }
        
        [Column("Lecturer_ID")]
        [ForeignKey("Lecturer")]
        [HiddenInput(DisplayValue = false)]
        public virtual int? Lecturer_ID { get; set; }

        [Column("Grade")]
        
        [Range(0, 5, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Grade { get; set; }

        [Column("Feedback")]
        [Required(AllowEmptyStrings = true)]
        [StringLength(200, ErrorMessage = "Feedback should be between 0 and 200 characters")]
        [DataType(DataType.MultilineText)]
        public string Feedback { get; set; }

        [Required]
        [Column("Status_ID")]
        [HiddenInput(DisplayValue = false)]
        public int Status_ID { get; set; }

        public virtual Student Student { get; set; }
        public virtual Lecturer Lecturer { get; set; }
    }
   
}