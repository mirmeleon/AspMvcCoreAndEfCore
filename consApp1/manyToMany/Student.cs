using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace manyToMany
{
   public class Student
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int CourseId { get; set; }

        public List<StudentCourse> Courses { get; set; } = new List<StudentCourse>();
    }
}
