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

        // GET: Default/Details/5
        [HttpGet]
        public ActionResult Details()
        {
            return View();
        }
        [HttpDelete]
        public ActionResult Delete()
        {
            return View();
        }
        
        [HttpPut]
        public ActionResult Change()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Add()
        {
            return View();
        }



    }
}
