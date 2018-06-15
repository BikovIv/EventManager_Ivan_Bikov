using EventManager_Ivan_Bikov.DataAccess;
using EventManager_Ivan_Bikov.Entities;
using System.Collections.Generic;
using System.Web.Mvc;

namespace EventManager_Ivan_Bikov.Controllers
{
    public class EventController : Controller
    {
        // GET: Event
        public ActionResult Index()
        {
            List<Event> events = new List<Event>();
            EventRepository eventRepository = new EventRepository();
            events.AddRange(eventRepository.GetAll());
            
            return View(events);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Event entity)
        {
            if (ModelState.IsValid)
            {
                var eventRepository = new EventRepository();
                eventRepository.Insert(entity);

                return RedirectToAction("Index");
            }

            return View(entity);
           
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var eventRepository = new EventRepository();
            Event entity = eventRepository.GetById(id);

            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Event entity)
        {
            if (ModelState.IsValid)
            {
                var eventRepository = new EventRepository();
                eventRepository.Update(entity);

                return RedirectToAction("Index");
            }
            return View(entity);
        }

        public ActionResult Delete(int id)
        {
            var eventRepository = new EventRepository();
            var entity = eventRepository.GetById(id);
            eventRepository.Delete(entity);

            return RedirectToAction("Index");
        }
    }
}