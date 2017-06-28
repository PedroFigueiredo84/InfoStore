using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InfoStore.DAL;
using InfoStore.Models;

namespace InfoStore.Controllers
{
    public class FacturaController : Controller
    {
        private LojaDB db = new LojaDB();

        // GET: Factura
        public ActionResult Index()
        {
            var facturas = db.Facturas.Include(f => f.Config).Include(f => f.Funcionario).Include(f => f.Produto);
            return View(facturas.ToList());
        }

        // GET: Factura/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factura factura = db.Facturas.Find(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            return View(factura);
        }

        // GET: Factura/Create
        public ActionResult Create()
        {
            ViewBag.ConfigID = new SelectList(db.Configs, "ConfigID", "ConfigID");
            ViewBag.FuncionarioID = new SelectList(db.Funcionarios, "FuncionarioID", "NomeFuncionario");
            ViewBag.ProdutoID = new SelectList(db.Produtos, "ProdutoID", "NomeProduto");
            return View();
        }

        // POST: Factura/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FacturaID,FuncionarioID,ProdutoID,ConfigID,Quant_Prod,Quant_Config")] Factura factura)
        {
            if (ModelState.IsValid)
            {
                db.Facturas.Add(factura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ConfigID = new SelectList(db.Configs, "ConfigID", "ConfigID", factura.ConfigID);
            ViewBag.FuncionarioID = new SelectList(db.Funcionarios, "FuncionarioID", "NomeFuncionario", factura.FuncionarioID);
            ViewBag.ProdutoID = new SelectList(db.Produtos, "ProdutoID", "NomeProduto", factura.ProdutoID);
            return View(factura);
        }

        // GET: Factura/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factura factura = db.Facturas.Find(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            ViewBag.ConfigID = new SelectList(db.Configs, "ConfigID", "ConfigID", factura.ConfigID);
            ViewBag.FuncionarioID = new SelectList(db.Funcionarios, "FuncionarioID", "NomeFuncionario", factura.FuncionarioID);
            ViewBag.ProdutoID = new SelectList(db.Produtos, "ProdutoID", "NomeProduto", factura.ProdutoID);
            return View(factura);
        }

        // POST: Factura/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FacturaID,FuncionarioID,ProdutoID,ConfigID,Quant_Prod,Quant_Config")] Factura factura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(factura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ConfigID = new SelectList(db.Configs, "ConfigID", "ConfigID", factura.ConfigID);
            ViewBag.FuncionarioID = new SelectList(db.Funcionarios, "FuncionarioID", "NomeFuncionario", factura.FuncionarioID);
            ViewBag.ProdutoID = new SelectList(db.Produtos, "ProdutoID", "NomeProduto", factura.ProdutoID);
            return View(factura);
        }

        // GET: Factura/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factura factura = db.Facturas.Find(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            return View(factura);
        }

        // POST: Factura/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Factura factura = db.Facturas.Find(id);
            db.Facturas.Remove(factura);
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
