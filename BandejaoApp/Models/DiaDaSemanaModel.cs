using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BandejaoApp.Models
{
    public class DiaDaSemanaModel
    {
        [Key]
        public int DiaDaSemanaId { get; set; }

        public CardapioModel Segunda { get; set; }

        public CardapioModel Terca { get; set; }

        public CardapioModel Quarta { get; set; }

        public CardapioModel Quinta { get; set; }

        public CardapioModel Sexta { get; set; }
    }
}