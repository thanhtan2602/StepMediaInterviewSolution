using StepMedia.Data.Entities;
using StepMedia.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace StepMedia.Model.Mappings
{
    public static class StudentMapping
    {
        public static StudentViewModel ToModel(this Student student)
        {
            return new StudentViewModel
            {
                StudentId = student.Id,
                FullName = student.FullName,
                DateOfBirth = student.DOB
            };
        }

        public static List<StudentViewModel> ToListModel(this List<Student> students)
        {
            var data = new List<StudentViewModel>();
            if (students?.Count > 0)
            {
                foreach (var item in students)
                {
                    data.Add(item.ToModel());
                }
            }

            return data;
        }
    }
}
