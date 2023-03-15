using System;
using System.Collections.Generic;
using System.Text;

namespace StepMedia.Data.Entities
{
    public class Teacher
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public List<Student> Students { get; set; }
    }
}
