using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CodingEvents.Models;
using CodingEvents.Data;

namespace CodingEvents.Controllers
{
    public class EventsController : Controller
    {
        //static List<string> events = new List<string>(); 
        //static Dictionary<string, string> events = new Dictionary<string, string>();
        
        //static private List<Event> Events = new List<Event>(); //After creating data folder
        //With data file, controller does not hold any data

        [HttpGet]
        public IActionResult Index()
        { 

            ViewBag.events = EventData.GetAll();

            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("/events/add")]
        public IActionResult NewEvent(Event newEvent) //Model-Binding
        {
            EventData.Add(newEvent);
            return Redirect("/Events");
        }

        [Route("/Events/Edit/{eventId}")] //eventId is part of the route, not submitted by form
        public IActionResult Edit(int eventId) //step1) to retrieve date
        {
            Event meeting = EventData.GetById(eventId);
            ViewBag.meeting = meeting;
            ViewBag.title = $"Edit Event {meeting.Name} (id = {meeting.Id})";
            return View();
        }

        [HttpPost]
        [Route("/events/edit")]
        public IActionResult SubmitEditEventForm(int eventId, string name, string description)//step2) to edit and submit
        {
            Event meeting = EventData.GetById(eventId);
            meeting.Name = name;
            meeting.Description = description;

            return Redirect("/Events");
        }

        public IActionResult Delete()
        {
            ViewBag.events = EventData.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] eventIds)
        {
            foreach (int id in eventIds)
            {
                EventData.Remove(id);
            }

            return Redirect("/Events");
        }
    }
}
