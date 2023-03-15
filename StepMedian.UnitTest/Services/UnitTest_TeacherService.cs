using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace StepMedia.UnitTest.Services
{
    [TestClass]
    public class UnitTest_TeacherService
    {
        private TeacherService _teacherSvc;

        public UnitTest_TeacherService()
        {
            _teacherSvc = new TeacherService();
        }

        [TestMethod]
        public void InsertData_ShouldCallInsertMethod()
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
            insertService.InsertData(data);

            // Assert
            mockDatabase.Verify(db => db.Insert(data), Times.Once);
        }
    }
}
