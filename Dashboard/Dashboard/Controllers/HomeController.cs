using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dashboard.Models;

namespace Dashboard.Controllers
{
    public class HomeController : Controller
    {
        private IGutachterRepository _repository;

        public HomeController(IGutachterRepository repository)
        {
            _repository = repository;
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            Gutachter gutachter = _repository.Read(1);

            return View(

                new
                {
                    Gutachter = gutachter,
                    HelloWorld = "Hello World"
                }.ToExpando()
                
            );
        }
    }
}
