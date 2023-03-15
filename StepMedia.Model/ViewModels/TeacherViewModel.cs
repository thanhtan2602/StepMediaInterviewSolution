using System;
using System.Collections.Generic;
using System.Text;

namespace StepMedia.Model.ViewModels
{
    public class TeacherViewModel
    {
        public string FullName { get; set; }
        public List<StudentViewModel> Students { get; set; }
        public int TeacherId { get; set; }
    }
}
