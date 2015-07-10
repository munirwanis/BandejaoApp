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

        public DbSet<VotesModel> Votes { get; set; }

        public DbSet<CardapioItemModel> CardapioItem { get; set; }

        public DbSet<CardapioModel> Cardapio { get; set; }
    }
}