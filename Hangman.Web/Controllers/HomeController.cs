﻿using Microsoft.AspNetCore.Mvc;

namespace Hangman.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: HomeController
        public ActionResult Index()
        {
            return View();
        }

    }
}
