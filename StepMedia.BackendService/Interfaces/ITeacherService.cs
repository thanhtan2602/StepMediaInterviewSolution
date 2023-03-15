using StepMedia.Data.Entities;
using StepMedia.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StepMedia.BackendService.Interfaces
{
    public interface ITeacherService
    {
        Task<List<TeacherViewModel>> GetTeacherList();
        Task<int> InsertTeacher(TeacherViewModel teacher);
        Task<int> UpdateTeacher(TeacherViewModel teacher);
    }
}
