using EventManager_Ivan_Bikov.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EventManager_Ivan_Bikov.DataAccess
{
    public class EventManagerDbContext : DbContext
    {
        public DbSet<Event> Events { get; set; }

        public EventManagerDbContext()
            :base("EventManager_Ivan_BikovDb")
        {

        }
    }
}