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
    public class ConfigController : Controller
    {
        private LojaDB db = new LojaDB();



        // GET: Config
        public ActionResult Index()
        {
            return View(db.Configs.ToList());
        }

        // GET: Config/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Config config = db.Configs.Find(id);
            if (config == null)
            {
                return HttpNotFound();
            }
            return View(config);
        }

        // GET: Config/Create
        public ActionResult Create()
        {
            ConfigViewModel config = new ConfigViewModel();
            config.Prod_Disponiveis = GetProdutos();


            return View(config);
        }

        // POST: Config/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PrecoConfig, ProdutosSelecionados")] ConfigViewModel ConfigViewModel)
        {
            if (ModelState.IsValid)
            {
                Config config = new Config();
                config.PrecoConfig = ConfigViewModel.PrecoConfig;
                foreach (int id in ConfigViewModel.ProdutosSelecionados)
                {
                    config.Produtos.Add(db.Produtos.Find(id));
                }

                db.Configs.Add(config);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ConfigViewModel);
        }

        private IList<SelectListItem> GetProdutos()
        {
            List<Produto> prod = new List<Produto>();
            prod = db.Produtos.ToList();
            List<SelectListItem> prod2 = new List<SelectListItem>();
            foreach (var item in prod)
            {
                prod2.Add(new SelectListItem { Text = item.NomeProduto, Value = item.ProdutoID.ToString() });
            }

            return prod2;

        }

        // GET: Config/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Config config = db.Configs.Find(id);
            if (config == null)
            {
                return HttpNotFound();
            }
            return View(config);
        }

        // POST: Config/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ConfigID,PrecoConfig")] Config config)
        {
            if (ModelState.IsValid)
            {
                db.Entry(config).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(config);
        }

        // GET: Config/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Config config = db.Configs.Find(id);
            if (config == null)
            {
                return HttpNotFound();
            }
            return View(config);
        }

        // POST: Config/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Config config = db.Configs.Find(id);
            db.Configs.Remove(config);
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
