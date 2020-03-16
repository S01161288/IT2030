using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace StudentEnrollment.Models
{
    public class Enrollment
    {
        public virtual int Id { get; set; }

        public virtual int StudentId { get; set; }
        public virtual  Student Student { get; set; }

        public virtual int CourseId { get; set; }
        public virtual Course Course { get; set; }

        [Required(ErrorMessage = "A Grade is required")]
        [RegularExpression("[a-zA-F]")]

        public virtual String Grade { get; set; }
       
        public virtual Boolean IsActive { get; set; }
        
        
        [Display(Name = "Assigned Campus")]
        [Required(ErrorMessage = "Campus must be assigned")]
        public virtual String AssingedCampus { get; set; }

        
        [Display(Name = "Enrolled in Semester")]
        [Required(ErrorMessage = "Enrollment Semester must be entered")]
        public virtual String EnrollmentSemester { get; set; }

        [Range(2018,2999,ErrorMessage = "Year cannot be earlier than 2018")]
        [Required(ErrorMessage = "Enrollment Year must be entered")]
        public virtual int EnrollmentYear { get; set; }


    }
}