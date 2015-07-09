using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using BandejaoApp.Models;

namespace BandejaoApp.Repository
{
    public class BandejaoContext : DbContext
    {
        public BandejaoContext() : base("BandejaoContext")
        {
            
        }

        public DbSet<DiaDaSemanaModel> DiaDaSemana { get; set; }
    }
}