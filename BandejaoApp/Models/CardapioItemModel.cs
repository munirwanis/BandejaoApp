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
        public int CardapioItemId { get; set; }
        
        public string Nome { get; set; }
    }
}