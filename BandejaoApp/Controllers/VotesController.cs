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
    public class VotesController : Controller
    {
        private BandejaoContext db = new BandejaoContext();

        // GET: Votes
        public ActionResult Index()
        {
            var votes = db.Votes.Include(v => v.CardapioItem);
            return View(votes.ToList());
        }

        // GET: Votes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VotesModel votesModel = db.Votes.Find(id);
            if (votesModel == null)
            {
                return HttpNotFound();
            }
            return View(votesModel);
        }

        // GET: Votes/Create
        public ActionResult Create()
        {
            ViewBag.CardapioItemId = new SelectList(db.CardapioItem, "CardapioItemId", "Nome");
            return View();
        }

        // POST: Votes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VoteId,Vote,CardapioItemId")] VotesModel votesModel)
        {
            if (ModelState.IsValid)
            {
                db.Votes.Add(votesModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CardapioItemId = new SelectList(db.CardapioItem, "CardapioItemId", "Nome", votesModel.CardapioItemId);
            return View(votesModel);
        }

        // GET: Votes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VotesModel votesModel = db.Votes.Find(id);
            if (votesModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.CardapioItemId = new SelectList(db.CardapioItem, "CardapioItemId", "Nome", votesModel.CardapioItemId);
            return View(votesModel);
        }

        // POST: Votes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VoteId,Vote,CardapioItemId")] VotesModel votesModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(votesModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CardapioItemId = new SelectList(db.CardapioItem, "CardapioItemId", "Nome", votesModel.CardapioItemId);
            return View(votesModel);
        }

        // GET: Votes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VotesModel votesModel = db.Votes.Find(id);
            if (votesModel == null)
            {
                return HttpNotFound();
            }
            return View(votesModel);
        }

        // POST: Votes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VotesModel votesModel = db.Votes.Find(id);
            db.Votes.Remove(votesModel);
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
