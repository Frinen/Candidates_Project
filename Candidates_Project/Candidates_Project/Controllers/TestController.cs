using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Candidates_Project.Controllers
{
    
    public class TestController : Controller
    {

        // GET: Default

        // GET: Default/Details/5
        [Route("api/TestController/Details")]
        [HttpGet]
        public ActionResult Details()
        {
            return View();
        }
        [Route("api/TestController/Delete")]
        [HttpDelete]
        public ActionResult Delete()
        {
            return View();
        }
        [Route("api/TestController/Change")]
        [HttpPut]
        public ActionResult Change()
        {
            return View();
        }
        [Route("api/TestController/Add")]
        [HttpPost]
        public ActionResult Add()
        {
            return View();
        }



    }
}
