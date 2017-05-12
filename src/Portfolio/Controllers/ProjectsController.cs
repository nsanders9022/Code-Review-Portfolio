﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;

namespace Portfolio.Controllers
{
    public class ProjectsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetProjects()
        {
            var projectList = Project.GetProjects();
            return Json(projectList);
        }
    }
}
