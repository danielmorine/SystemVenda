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
    public class VendaController : Controller
    {
        private EFContext db = new EFContext();

        // GET: Venda
        public ActionResult Index()
        {
            var vendas = db.vendas.Include(v => v.produtos).Include(v => v.vendedores);
            return View(vendas.ToList());
        }

        // GET: Venda/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venda venda = db.vendas.Find(id);
            if (venda == null)
            {
                return HttpNotFound();
            }
            return View(venda);
        }

        // GET: Venda/Create
        public ActionResult Create()
        {
            ViewBag.IdProduto = new SelectList(db.produtos, "idProduto", "nomeProduto");
            ViewBag.IdVendedor = new SelectList(db.vendedores, "idVendedor", "nomeVendedor");
            return View();
        }

        // POST: Venda/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdVenda,IdProduto,IdVendedor")] Venda venda)
        {
            if (ModelState.IsValid)
            {
                db.vendas.Add(venda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdProduto = new SelectList(db.produtos, "idProduto", "nomeProduto", venda.IdProduto);
            ViewBag.IdVendedor = new SelectList(db.vendedores, "idVendedor", "nomeVendedor", venda.IdVendedor);
            return View(venda);
        }

        // GET: Venda/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venda venda = db.vendas.Find(id);
            if (venda == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdProduto = new SelectList(db.produtos, "idProduto", "nomeProduto", venda.IdProduto);
            ViewBag.IdVendedor = new SelectList(db.vendedores, "idVendedor", "nomeVendedor", venda.IdVendedor);
            return View(venda);
        }

        // POST: Venda/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdVenda,IdProduto,IdVendedor")] Venda venda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(venda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdProduto = new SelectList(db.produtos, "idProduto", "nomeProduto", venda.IdProduto);
            ViewBag.IdVendedor = new SelectList(db.vendedores, "idVendedor", "nomeVendedor", venda.IdVendedor);
            return View(venda);
        }

        // GET: Venda/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venda venda = db.vendas.Find(id);
            if (venda == null)
            {
                return HttpNotFound();
            }
            return View(venda);
        }

        // POST: Venda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Venda venda = db.vendas.Find(id);
            db.vendas.Remove(venda);
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
