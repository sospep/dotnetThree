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
            ViewData["h2"] ="dotnetThree - Blog Application - Features";
            return View();             
        }
    }
}