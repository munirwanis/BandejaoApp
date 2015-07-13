using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BandejaoApp.Models
{
    public class CardapioModel
    {
        [Key]
        public int CardapioId { get; set; }

        public string DiaDaSemana { get; set; }

        public ICollection<CardapioItemModel> Itens { get; set; }
    }
}