using FP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace FP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [ActionName("SendingImage")]
        public IActionResult Image()
        {
            return View("SendingImage");
        }

        [HttpPost]
        public IActionResult SendingImage()
        {
            var file = Request.Form.Files.GetFile("file");
            FileStream stream = new FileStream("wwwroot/file.jpg",
                FileMode.Create);
            file.CopyTo(stream);
            stream.Close();
            return View();
        }
        static void blur_process()//this is the blur filter i want to apply but idk how to
        {
            Bitmap picture = new Bitmap("wwwroot/file.jpg");
            var radius = 10;
            StackBlur.StackBlur.Process(picture, radius);
            picture.Save("wwwroot/blurred_picture.jpg");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
