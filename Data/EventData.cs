﻿using CodingEvents.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEvents.Data
{
    public class EventData
    {
        static Dictionary<int, Event> Events = new Dictionary<int, Event>();
        public static IEnumerable<Event> GetAll()
        {
            return Events.Values;
        }

        public static void Add(Event newEvent)
        {
            Events.Add(newEvent.Id, newEvent);
        }

        public static void Remove(int id) // dictionary, remove item with key
        {
            Events.Remove(id);
        }

        public static Event GetById(int id)
        {
            return Events[id];
        }

    }
}
