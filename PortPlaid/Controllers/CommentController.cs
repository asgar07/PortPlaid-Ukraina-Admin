﻿using Microsoft.AspNetCore.Mvc;

namespace PortPlaid.Controllers
{
    public class CommentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
