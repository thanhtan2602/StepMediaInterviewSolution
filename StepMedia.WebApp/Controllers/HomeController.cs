using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StepMedia.BackendService.Interfaces;
using StepMedia.Data.EF;
using StepMedia.Data.Entities;
using StepMedia.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StepMedia.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly StepMediaDbContext _dbContext;
        private readonly ITeacherService _teacherSvc;

        public HomeController(
            ILogger<HomeController> logger,
            StepMediaDbContext dbContext,
            ITeacherService teacherSvc)
        {
            _logger = logger;
            _dbContext = dbContext;
            _teacherSvc = teacherSvc;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _teacherSvc.GetTeacherList();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(TeacherViewModel teacher, List<StudentViewModel> students)
        {
            var response = 0;
            if (teacher.TeacherId > 0)
                response = await _teacherSvc.UpdateTeacher(teacher);
            else
                response = await _teacherSvc.InsertTeacher(teacher);

            if (response > 0)
                return new JsonResult(new { success = true, message = "success" });

            return new JsonResult(new { success = false, message = "Something is wrong :(" });
        }
    }
}
