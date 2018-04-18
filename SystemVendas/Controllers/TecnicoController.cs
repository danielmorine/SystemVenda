using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SystemVendas.Models;
using SystemVendas.RepositoryEF;

namespace SystemVendas.Controllers
{
    public class TecnicoController : Controller
    {
        private EFContext db = new EFContext();

        // GET: Tecnico
        public ActionResult Index()
        {
            return View(db.tecnicos.ToList());
        }

        // GET: Tecnico/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tecnico tecnico = db.tecnicos.Find(id);
            if (tecnico == null)
            {
                return HttpNotFound();
            }
            return View(tecnico);
        }

        // GET: Tecnico/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tecnico/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTecnico,NomeDotecnico,TelefoneTecnico,EmailTecnico")] Tecnico tecnico)
        {
            if (ModelState.IsValid)
            {
                db.tecnicos.Add(tecnico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tecnico);
        }

        // GET: Tecnico/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tecnico tecnico = db.tecnicos.Find(id);
            if (tecnico == null)
            {
                return HttpNotFound();
            }
            return View(tecnico);
        }

        // POST: Tecnico/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTecnico,NomeDotecnico,TelefoneTecnico,EmailTecnico")] Tecnico tecnico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tecnico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tecnico);
        }

        // GET: Tecnico/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tecnico tecnico = db.tecnicos.Find(id);
            if (tecnico == null)
            {
                return HttpNotFound();
            }
            return View(tecnico);
        }

        // POST: Tecnico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tecnico tecnico = db.tecnicos.Find(id);
            db.tecnicos.Remove(tecnico);
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
