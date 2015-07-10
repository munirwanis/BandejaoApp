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

namespace BandejaoApp.Controllers
{
    public class BandejaoController : Controller
    {
        private BandejaoContext db = new BandejaoContext();

        // GET: Bandejao
        public ActionResult Index()
        {
            return View(db.Cardapio.ToList());
        }

        // GET: Bandejao/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CardapioModel cardapioModel = db.Cardapio.Find(id);
            if (cardapioModel == null)
            {
                return HttpNotFound();
            }
            return View(cardapioModel);
        }

        // GET: Bandejao/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bandejao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CardapioId,DiaDaSemana")] CardapioModel cardapioModel)
        {
            if (ModelState.IsValid)
            {
                db.Cardapio.Add(cardapioModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cardapioModel);
        }

        // GET: Bandejao/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CardapioModel cardapioModel = db.Cardapio.Find(id);
            if (cardapioModel == null)
            {
                return HttpNotFound();
            }
            return View(cardapioModel);
        }

        // POST: Bandejao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CardapioId,DiaDaSemana")] CardapioModel cardapioModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cardapioModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cardapioModel);
        }

        // GET: Bandejao/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CardapioModel cardapioModel = db.Cardapio.Find(id);
            if (cardapioModel == null)
            {
                return HttpNotFound();
            }
            return View(cardapioModel);
        }

        // POST: Bandejao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CardapioModel cardapioModel = db.Cardapio.Find(id);
            db.Cardapio.Remove(cardapioModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

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
