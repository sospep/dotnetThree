using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using Microsoft.Extensions.Logging;

namespace dotnetThree.Controllers
{
    public class PagesController : Controller
    {
        // 
        // GET: /Pages/
        private readonly ILogger<PagesController> _logger;

        public PagesController(ILogger<PagesController> logger)
        {
            _logger = logger;
        }

        public string Index()
        {
             // return View(); 
            return "This is the Pages - Index action method... replace this with a list of"  ;                       
        }
        

        public IActionResult About()
        {
            // example - setting variable to pass into the view using the ViewData dictionary object
            ViewData["appName"] ="dotnetThree - duh Blog";
            // TEST = embed html in variable, r= FAIL
            // ViewData["appDescription"] ="dotnetThree is an application used to create blog Articles Check out the <a href=\"\\Pages\\LearnMore\">Learn More</a> page to read about some of its cool features."; 
            ViewData["appDescription"] ="The dotnetThree application is used to create blog Articles Check out the \"Learn More\" page to read about some of the cool features it has."; 
            ViewData["appVersion"] ="0.18.0-alpha";
            return View();             
        }
         public IActionResult LearnMore()
        {
            //ViewData["h2"] ="dotnetThree - Blog Application - Features";
            return View();             
        }
         public IActionResult ChangeLog()
        {
            return View();             
        }
    }
}