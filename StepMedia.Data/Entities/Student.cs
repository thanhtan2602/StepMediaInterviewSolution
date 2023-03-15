using System;
using System.Collections.Generic;
using System.Text;

namespace StepMedia.Data.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime DOB { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
