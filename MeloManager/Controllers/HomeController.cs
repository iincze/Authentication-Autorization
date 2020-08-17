using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeloManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace MeloManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public string Index()
        {
            return _employeeRepository.GetEmployee(1).Name;
        }
    }
}