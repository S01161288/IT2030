using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentEnrollment.Models
{
    public class Course
    {
        public virtual int Id { get; set; }
        public virtual String Title { get; set; }
        public virtual String Description { get; set; }
        public virtual String Credits { get; set; }
    }
}