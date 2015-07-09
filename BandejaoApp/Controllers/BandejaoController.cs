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
            return View(db.DiaDaSemana.ToList());
        }

        // GET: Bandejao/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiaDaSemanaModel diaDaSemanaModel = db.DiaDaSemana.Find(id);
            if (diaDaSemanaModel == null)
            {
                return HttpNotFound();
            }
            return View(diaDaSemanaModel);
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
        public ActionResult Create([Bind(Include = "DiaDaSemanaId,Segunda,Terca,Quarta,Quinta,Sexta")] DiaDaSemanaModel diaDaSemanaModel)
        {
            if (ModelState.IsValid)
            {
                db.DiaDaSemana.Add(diaDaSemanaModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(diaDaSemanaModel);
        }

        // GET: Bandejao/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiaDaSemanaModel diaDaSemanaModel = db.DiaDaSemana.Find(id);
            if (diaDaSemanaModel == null)
            {
                return HttpNotFound();
            }
            return View(diaDaSemanaModel);
        }

        // POST: Bandejao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DiaDaSemanaId,Segunda,Terca,Quarta,Quinta,Sexta")] DiaDaSemanaModel diaDaSemanaModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(diaDaSemanaModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(diaDaSemanaModel);
        }

        // GET: Bandejao/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiaDaSemanaModel diaDaSemanaModel = db.DiaDaSemana.Find(id);
            if (diaDaSemanaModel == null)
            {
                return HttpNotFound();
            }
            return View(diaDaSemanaModel);
        }

        // POST: Bandejao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DiaDaSemanaModel diaDaSemanaModel = db.DiaDaSemana.Find(id);
            db.DiaDaSemana.Remove(diaDaSemanaModel);
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
