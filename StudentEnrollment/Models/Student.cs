using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
 

namespace StudentEnrollment.Models
{
    public class Student : IValidatableObject
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
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public string State { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            
            if(Address1 == Address2)
            {
                yield return (new ValidationResult("Address 1 and Address 2 cannot be the same."));
            }
            if(State.Length > 2 || State.Length < 2)
            {
                yield return (new ValidationResult("State cannot have more than two digits."));
            }
            if(Zipcode.Length != 5)
            {
                yield return (new ValidationResult("Zipcode needs more than two digits."));
            }


            
        }
    }
}