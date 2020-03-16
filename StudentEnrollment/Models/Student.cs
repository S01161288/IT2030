using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace StudentEnrollment.Models
{
    public class Student
    {
        [Display(Name = "Student ID")]
        public virtual int Id { get; set; }
        
        
        [Display(Name = "Last Name")]
        [Required (ErrorMessage = "Last name is required")]
        [StringLength(50,ErrorMessage = "Last name cannot be more than 50 characters")]
        public virtual String LastName { get; set; }
        
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First name is required")]
        [StringLength(50, ErrorMessage = "First name cannot be more than 50 characters")]
        public virtual String FirstName { get; set; }
    }
}