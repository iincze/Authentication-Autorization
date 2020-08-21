using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeloManager.Controllers
{
    public class DepartmentsController : Controller
    {
        public string List()
        {
            return "List() of DepartmentsController";
        }

        public string Details()
        {
            return "Details() of DepartmentsController";
        }
    }
}
