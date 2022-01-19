using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vilage.Controllers.API
{
    public class ChiffController : Controller
    {
        // GET: Chiff
        public ActionResult ShowChif()
        {
            ViewBag.title = "welcome chif";
            return View();
        }
    }
}