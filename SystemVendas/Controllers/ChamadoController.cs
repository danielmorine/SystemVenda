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
    public class ChamadoController : Controller
    {
        private EFContext db = new EFContext();

        // GET: Chamado
        public ActionResult Index()
        {
            var chamados = db.chamados.Include(c => c.empresas).Include(c => c.tecnicos);
            return View(chamados.ToList());
        }

        // GET: Chamado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chamado chamado = db.chamados.Find(id);
            if (chamado == null)
            {
                return HttpNotFound();
            }
            return View(chamado);
        }

        // GET: Chamado/Create
        public ActionResult Create()
        {
            ViewBag.IdEmpresa = new SelectList(db.empresas, "IdEmpresa", "NomeEmpresa");
            ViewBag.IdTecnico = new SelectList(db.tecnicos, "IdTecnico", "NomeDotecnico");
            return View();
        }

        // POST: Chamado/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdChamado,IdTecnico,IdEmpresa")] Chamado chamado)
        {
            if (ModelState.IsValid)
            {
                db.chamados.Add(chamado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdEmpresa = new SelectList(db.empresas, "IdEmpresa", "NomeEmpresa", chamado.IdEmpresa);
            ViewBag.IdTecnico = new SelectList(db.tecnicos, "IdTecnico", "NomeDotecnico", chamado.IdTecnico);
            return View(chamado);
        }

        // GET: Chamado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chamado chamado = db.chamados.Find(id);
            if (chamado == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEmpresa = new SelectList(db.empresas, "IdEmpresa", "NomeEmpresa", chamado.IdEmpresa);
            ViewBag.IdTecnico = new SelectList(db.tecnicos, "IdTecnico", "NomeDotecnico", chamado.IdTecnico);
            return View(chamado);
        }

        // POST: Chamado/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdChamado,IdTecnico,IdEmpresa")] Chamado chamado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chamado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdEmpresa = new SelectList(db.empresas, "IdEmpresa", "NomeEmpresa", chamado.IdEmpresa);
            ViewBag.IdTecnico = new SelectList(db.tecnicos, "IdTecnico", "NomeDotecnico", chamado.IdTecnico);
            return View(chamado);
        }

        // GET: Chamado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chamado chamado = db.chamados.Find(id);
            if (chamado == null)
            {
                return HttpNotFound();
            }
            return View(chamado);
        }

        // POST: Chamado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Chamado chamado = db.chamados.Find(id);
            db.chamados.Remove(chamado);
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
