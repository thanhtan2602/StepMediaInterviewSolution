using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace StepMedian.UnitTest.Services
{
    [TestClass]
    public class UnitTest_TeacherService
    {
        private readonly ITeacherService _teacherSvc;

        public UnitTest_TeacherService(ITeacherService teacherSvc)
        {
            _teacherSvc = teacherSvc;
        }

        [TestMethod]
        public void UnitTest_TeacherService_InsertTeacher()
        {
            // Arrange
            var students = new List<StudentViewModel>
            {
                new StudentViewModel
                {
                    FullName = "Student of John 1",
                    DateOfBirth = new DateTime(2000, 09, 02)
                },
                new StudentViewModel
                {
                    FullName = "Student of John 2",
                    DateOfBirth = new DateTime(2001, 09, 01)
                }
            }
            var data = new TeacherViewModel { FullName = "John", Students = students };

            // Act
            _teacherSvc.InsertTeacher(data);

            // Assert
            mockDatabase.Verify(db => db.Insert(data), Times.Once);
        }
    }
}
