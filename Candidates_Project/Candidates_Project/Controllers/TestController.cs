using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Candidates_Project.Controllers
{
    [Route("api/TestController")]
    public class TestController : Controller
    {

        // GET: Default
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        // GET: Default/Details/5
        [HttpPost]
        public ActionResult Details(int id)
        {
            return View();
        }

        
    }
}
