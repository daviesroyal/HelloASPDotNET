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
            string selectLanguage = "<select name='language'>" +
                "<option value='en'>English</option>" +
                "<option value='fr'>French</option>" +
                "<option value='sp'>Spanish</option>" +
                "<option value='it'>Italian</option>" +
                "<option value='ga'>Gaelic Irish</option>" +
                "</select>";
            string html = "<form method='post' action='/hello'>" +
               "<input type='text' name='name' />" +
               selectLanguage +
               "<input type='submit' value='Greet Me!' />" +
               "</form>";
            return Content(html, "text/html");
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
            string message = CreateMessage(name, language);
            return Content($"<h1>{message}</h1>", "text/html");
        }
    }
}
