using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace dojodachi_proj.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            if(HttpContext.Session.GetObjectFromJson<Dojodachi>("pet") == null)
            {
                Dojodachi hector = new Dojodachi();
                HttpContext.Session.SetObjectAsJson("pet", hector);
            }
            ViewBag.hector = HttpContext.Session.GetObjectFromJson<Dojodachi>("pet");
            if(ViewBag.hector.fullness < 1 || ViewBag.hector.happiness < 1)
            {
                ViewBag.hector.message = "I died.";
            }
            if(ViewBag.hector.fullness == 100 && ViewBag.hector.happiness >= 100 && ViewBag.hector.energy == 100)
            {
                ViewBag.hector.message = "You took good care of me, I am eternally grateful.";
            }
            return View("Index");
        }
        [HttpGet]
        [Route("feed")]
        public IActionResult Feed()
        {
            Dojodachi hector = HttpContext.Session.GetObjectFromJson<Dojodachi>("pet");
            hector.Feed();
            HttpContext.Session.SetObjectAsJson("pet", hector);
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("play")]
        public IActionResult Play()
        {
            Dojodachi hector = HttpContext.Session.GetObjectFromJson<Dojodachi>("pet");
            hector.Play();
            HttpContext.Session.SetObjectAsJson("pet", hector);
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("work")]
        public IActionResult Work()
        {
            Dojodachi hector = HttpContext.Session.GetObjectFromJson<Dojodachi>("pet");
            hector.Work();
            HttpContext.Session.SetObjectAsJson("pet", hector);
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("sleep")]
        public IActionResult Sleep()
        {
            Dojodachi hector = HttpContext.Session.GetObjectFromJson<Dojodachi>("pet");
            hector.Sleep();
            HttpContext.Session.SetObjectAsJson("pet", hector);
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("reset")]
        public IActionResult Reset()
        {
            Dojodachi hector = new Dojodachi();
            HttpContext.Session.SetObjectAsJson("pet", hector);
            return RedirectToAction("Index");
        }
    }
}