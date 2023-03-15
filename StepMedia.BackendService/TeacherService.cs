using StepMedia.BackendService.Interfaces;
using StepMedia.Data.EF;
using StepMedia.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using StepMedia.Model.Mappings;
using Microsoft.EntityFrameworkCore;
using StepMedia.Data.Entities;

namespace StepMedia.BackendService
{
    public class TeacherService : ITeacherService
    {
        private readonly StepMediaDbContext _dbContext;
        public TeacherService(StepMediaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<TeacherViewModel>> GetTeacherList(int pageIndex = 0, int pageSize = 5)
        {
            var data = await _dbContext.Teachers
                .AsNoTracking()
                .OrderBy(x => x.FullName)
                .Skip((pageIndex) * pageSize)
                .Take(pageSize)
                .Select(x => new TeacherViewModel()
                {
                    TeacherId = x.Id,
                    FullName = x.FullName,
                    Students = x.Students.OrderBy(x => x.DOB).ToList().ToListModel()
                }).ToListAsync();

            return data;
        }

        public async Task<int> InsertTeacher(TeacherViewModel teacher)
        {
            // Create teacher
            var newTeacher = new Teacher
            {
                FullName = teacher.FullName,
            };

            var students = new List<Student>();
            if (teacher.Students != null && teacher.Students.Count > 0)
            {
                foreach (var studentViewModel in teacher.Students)
                {
                    students.Add(new Student
                    {
                        FullName = studentViewModel.FullName,
                        DOB = studentViewModel.DateOfBirth,
                        Teacher = newTeacher
                    });
                }
            }

            newTeacher.Students = students;

            _dbContext.Teachers.Add(newTeacher);
            await _dbContext.SaveChangesAsync();

            return newTeacher.Id;
        }

        public async Task<int> UpdateTeacher(TeacherViewModel teacher)
        {
            //Check exist
            var existTeacher = await _dbContext.Teachers.FindAsync(teacher.TeacherId);
            if (existTeacher == null)
                return 0;
            else
            {
                existTeacher.FullName = teacher.FullName;
                existTeacher.Students = _dbContext.Students.Where(x => x.TeacherId == teacher.TeacherId).ToList();
                _dbContext.Teachers.Update(existTeacher);
            }

            //Update students of teacher
            if (teacher.Students != null && teacher.Students.Count > 0)
            {
                foreach (var item in teacher.Students)
                {
                    //Update
                    if (item.StudentId > 0)
                    {
                        //Check exist
                        var existStudent = await _dbContext.Students.FindAsync(item.StudentId);
                        if (existStudent == null)
                            continue;
                        else
                        {
                            existStudent.FullName = item.FullName;
                            existStudent.DOB = item.DateOfBirth;

                            _dbContext.Students.Update(existStudent);
                        }
                    }
                    else //Creat
                    {
                        var newStudent = new Student
                        {
                            FullName = item.FullName,
                            DOB = item.DateOfBirth,
                            Teacher = existTeacher
                        };

                        _dbContext.Students.Add(newStudent);
                    }

                }
            }

            await _dbContext.SaveChangesAsync();

            return teacher.TeacherId;
        }
    }
}
