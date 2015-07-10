using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;

namespace BandejaoApp.Models
{
    public class VotesModel
    {
        [Key]
        public int VoteId { get; set; }

        public int Vote { get; set; }

        public int CardapioItemId { get; set; }

        [ForeignKey("CardapioItemId")]
        public CardapioItemModel CardapioItem { get; set; }
    }
}