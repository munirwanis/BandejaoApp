using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BandejaoApp.Models;
using BandejaoApp.Repository;
using Microsoft.Ajax.Utilities;

namespace BandejaoApp.Controllers
{
    public class BandejaoController : Controller
    {
        private BandejaoContext db = new BandejaoContext();

        // GET: Bandejao
        public ActionResult Index()
        {
            var cardapioItem = db.CardapioItem.Include(c => c.CardapioModel).Include(x => x.Votes);

            return View(cardapioItem.ToList());
        }

        // GET: Bandejao/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CardapioItemModel cardapioItemModel = db.CardapioItem.Find(id);
            if (cardapioItemModel == null)
            {
                return HttpNotFound();
            }
            return View(cardapioItemModel);
        }

        // GET: Bandejao/Create
        public ActionResult Create()
        {
            ViewBag.CardapioId = new SelectList(db.Cardapio, "CardapioId", "DiaDaSemana");
            return View();
        }

        // POST: Bandejao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CardapioItemId,Nome,CardapioId")] CardapioItemModel cardapioItemModel)
        {
            if (ModelState.IsValid)
            {
                db.CardapioItem.Add(cardapioItemModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CardapioId = new SelectList(db.Cardapio, "CardapioId", "DiaDaSemana", cardapioItemModel.CardapioId);
            return View(cardapioItemModel);
        }

        // GET: Bandejao/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CardapioItemModel cardapioItemModel = db.CardapioItem.Find(id);
            if (cardapioItemModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.CardapioId = new SelectList(db.Cardapio, "CardapioId", "DiaDaSemana", cardapioItemModel.CardapioId);
            return View(cardapioItemModel);
        }

        // POST: Bandejao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CardapioItemId,Nome,CardapioId")] CardapioItemModel cardapioItemModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cardapioItemModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CardapioId = new SelectList(db.Cardapio, "CardapioId", "DiaDaSemana", cardapioItemModel.CardapioId);
            return View(cardapioItemModel);
        }

        // GET: Bandejao/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CardapioItemModel cardapioItemModel = db.CardapioItem.Find(id);
            if (cardapioItemModel == null)
            {
                return HttpNotFound();
            }
            return View(cardapioItemModel);
        }

        // POST: Bandejao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CardapioItemModel cardapioItemModel = db.CardapioItem.Find(id);
            db.CardapioItem.Remove(cardapioItemModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Calculando Media dos votos
        #region Criar Média
        public void VotosMedia()
        {
            // carrego os itens do cardápio com votos
            var cardapioItem = db.CardapioItem.Include(x => x.Votes);
            float media = 0;

            // para cada item do cardápio verifico se possui algum voto
            foreach (var item in cardapioItem)
            {
                if (item.Votes.Count() != 0)
                {
                    // para vada voto somo na média a sua nota
                    foreach (var voteItem in item.Votes)
                    {
                        media += voteItem.Vote;
                    }

                    // faço a média aritmética, guardo a média na tabela e zero a variável
                    media = media / item.Votes.Count();
                    item.MediaVotos = media;
                    media = 0;
                }
            }

            // salvo as mudanças
            if (ModelState.IsValid)
            {
                db.SaveChanges();
            }

        }
        #endregion

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
