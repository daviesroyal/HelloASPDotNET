using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloASPDotNET.Controllers
{
    [Route("/hello/")]
    public class HelloController : Controller
    {
 
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public static string CreateMessage(string name = "World", string language = "en")
        {
            string message = "";
            if (language == "fr")
            {
                message = $"Bonjour, {name}!";
            } else if (language == "sp")
            {
                message = $"&#161Hola, {name}!";
            } else if (language == "it")
            {
                message = $"Ciao, {name}!";
            } else if (language == "ga")
            {
                message = $"Dia dhuit, {name}!";
            } else
            {
                message = $"Hello, {name}!";
            }
            return message;
        }

        [HttpPost, Route("/hello")]
        public IActionResult Welcome(string name, string language)
        {
            ViewBag.message = CreateMessage(name, language);
            return View();
        }
    }
}
