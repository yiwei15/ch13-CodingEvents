﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CodingEvents.Controllers
{
    public class EventsController : Controller
    {
        static List<string> events = new List<string>(); 

        [HttpGet]
        public IActionResult Index()
        {
            //Events.Add("The Ball");
            //Events.Add("STL Wine Mixer");
            //Events.Add("Engine Rev Fest");

            ViewBag.events = events;

            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("/events/add")]
        public IActionResult NewEvent(string name)
        {
            events.Add(name);
            return Redirect("/Events");
        }
    }
}
