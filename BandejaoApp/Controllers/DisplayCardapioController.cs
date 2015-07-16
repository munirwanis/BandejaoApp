using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BandejaoApp.Dto;
using BandejaoApp.Models;
using BandejaoApp.Repository;
using WebGrease.Css.Extensions;

namespace BandejaoApp.Controllers
{
    public class DisplayCardapioController : Controller
    {
        private BandejaoContext db = new BandejaoContext();

        // GET: DisplayCardapio
        public ActionResult Index()
        {
            // Pego o cardápio no Db
            var cardapioItem = db.CardapioItem.Include(c => c.CardapioModel).Include(x => x.Votes).ToList();
            var diaDaSemana = db.Cardapio;

            var cardapioView = new List<CardapioDto>();

            // Percorro os dias da semana
            diaDaSemana.ForEach(x =>
            {
                var cardapioItemList = new CardapioDto();

                // query usando LINQ faz a mesma coisa da de baixo. Está aqui de exemplo
                #region usando LINQ
                //var query = (from item in cardapioItem
                //    where item.CardapioId == x.CardapioId
                //    select new PratoNota
                //    {
                //        CardapioId = item.CardapioItemId,
                //        CardapioItemId = item.CardapioId,
                //        ItemDoCardapio = item.Nome,
                //        MediaDoItem = item.MediaVotos
                //    }).ToList();
                #endregion

                // preencho a variável resposta com os itens necessários pra preencher o objeto CardapioDto
                var resposta = cardapioItem.Where(y => y.CardapioId == x.CardapioId)
                    .Select(y => new PratoNota()
                    {
                        CardapioId = y.CardapioId,
                        CardapioItemId = y.CardapioItemId,
                        ItemDoCardapio = y.Nome,
                        MediaDoItem = y.MediaVotos
                    }).ToList();

                // preencho o CardapioDto
                cardapioItemList.DiaDaSemana = x.DiaDaSemana;
                cardapioItemList.PratosNotas = resposta;

                // adiciono na lista que será mandada para a view
                cardapioView.Add(cardapioItemList);
            });

            return View(cardapioView.ToList());
        }
    }
}