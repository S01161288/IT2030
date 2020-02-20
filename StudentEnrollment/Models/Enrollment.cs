using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentEnrollment.Models
{
    public class Enrollment
    {
        public virtual int Id { get; set; }

        public virtual int StudentId { get; set; }
        public virtual  Student Student { get; set; }

        public virtual int CourseId { get; set; }
        public virtual Course Course { get; set; }

        public virtual String Grade { get; set; }
    }
}