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
        Task<List<TeacherViewModel>> GetTeacherList(int pageIndex = 0, int pageSize = 5);
        Task<int> InsertTeacher(TeacherViewModel teacher);
        Task<int> UpdateTeacher(TeacherViewModel teacher);
    }
}
