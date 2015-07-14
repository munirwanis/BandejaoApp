using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BandejaoApp.Models
{
    public class CardapioItemModel
    {
        [Key]
        [Display(Name = "Item do Cardápio")]
        public int CardapioItemId { get; set; }
        
        public string Nome { get; set; }

        [Display(Name = "Dia da Semana")]
        public int CardapioId { get; set; }

        [ForeignKey("CardapioId")]
        public CardapioModel CardapioModel { get; set; }

        public ICollection<VotesModel> Votes { get; set; }

        //public float MediaVotos { get; set; }
    }
}