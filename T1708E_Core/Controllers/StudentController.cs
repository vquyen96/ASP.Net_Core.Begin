using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using T1708E_Core.Models;

namespace T1708E_Core.Controllers
{
    
    public class StudentController : Controller
    {
        [HttpGet("/student")]
        public IActionResult Index()
        {
            return View();
        }

    }


    
}