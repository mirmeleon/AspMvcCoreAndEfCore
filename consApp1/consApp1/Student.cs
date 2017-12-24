using System;
using System.Collections.Generic;
using System.Text;

namespace consApp1
{
   public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }

        //polzame mejdinnata tablica
        public List<StudentCourse> Courses { get; set; } = new List<StudentCourse>();


    }
}
