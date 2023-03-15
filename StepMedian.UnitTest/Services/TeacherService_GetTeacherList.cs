using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace StepMedian.UnitTest.Services
{
    [TestClass]
    public class TeacherService_GetTeacherList
    {
        private readonly ITeacherService _teacherSvc;

        public TeacherService_GetTeacherList(ITeacherService teacherSvc)
        {
            _teacherSvc = teacherSvc;
        }

        [TestMethod]
        public void IsPrime_InputIs1_ReturnFalse()
        {
            List<TeacherViewModel> result = _teacherSvc.GetTeacherList(1);

            Assert.IsFalse(result, "1 should not be prime");
        }
    }
}
