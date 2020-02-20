using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentEnrollment.Models
{
    public class Student
    {
        public virtual int Id { get; set; }
        public virtual String LastName { get; set; }
        public virtual String FirstName { get; set; }
    }
}