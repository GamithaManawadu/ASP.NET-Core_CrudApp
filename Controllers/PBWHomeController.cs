using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TestTemp1.Models;

namespace TestTemp1.Controllers
{
    [Authorize]
    public class PBWHomeController : Controller
    {
        private readonly ILogger<PBWHomeController> _logger;

        public PBWHomeController(ILogger<PBWHomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}
