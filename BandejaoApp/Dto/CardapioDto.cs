using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BandejaoApp.Dto
{
    public class CardapioDto
    {
        public string DiaDaSemana { get; set; }

        public List<PratoNota> PratosNotas { get; set; }
    }

    public class PratoNota
    {
        public int CardapioItemId { get; set; }

        public int CardapioId { get; set; }

        public string ItemDoCardapio { get; set; }

        public double? MediaDoItem { get; set; }
    }
}