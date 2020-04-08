using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace StudentEnrollment.Models
{
    public class InvalidCharsAttribute : ValidationAttribute
    {
        private string invalidChars;
        public InvalidCharsAttribute(string invalidChars) : base ("{0} contains unacceptable characters")
        {
            this.invalidChars = invalidChars;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string userinput = (string)value;
            char[] input = userinput.ToCharArray();

            foreach( char ui in input )
            {
                if (this.invalidChars.Contains(ui))
                {
                    //Display an Error message
                    var errormessage = FormatErrorMessage(validationContext.DisplayName);
                    return new ValidationResult(ErrorMessage);
                }


            }
            //return a success status
            return ValidationResult.Success;
        }
        
    }
}