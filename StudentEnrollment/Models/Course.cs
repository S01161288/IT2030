using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace StudentEnrollment.Models
{
    public class Course
    {
        [Display(Name = "Course ID")]
        public virtual int Id { get; set; }
       
        [Display(Name = "Course Title")]
        [Required(ErrorMessage = "Course Title is required.")]
        [StringLength (150,ErrorMessage = "Course Title cannot be longer than 150 characters")]
        public virtual String Title { get; set; }
        
        [Display(Name = "Description")]
        public virtual String Description { get; set; }
        
        [Display(Name = "Number of credits")]
        [Required(ErrorMessage = "Must enter number of course credits")]
        [Range(1,4,ErrorMessage = "Credits cannot be more than 4")]
        public virtual String Credits { get; set; }
        
    }
}