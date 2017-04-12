using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MedidorEnergia.BLL;
using MedidorEnergia.DTO;
using System.Net;

namespace MedidorEnergia.Controllers
{
    public class MedidaController : Controller
    {
        private MedidaBLL BLL = new MedidaBLL();
        // GET: Medida
        public ActionResult Index()
        {

            return View(BLL.Lista());
        }

        // GET: Medida/Details/5
        public ActionResult Details(int id)
        {
            if (id == null) { return new HttpStatusCodeResult(HttpStatusCode.BadRequest); }
            var medidaID= BLL.BuscaPorId(id);
            return View(medidaID);
        }

        // GET: Medida/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Medida/Create
        [HttpPost]
        public ActionResult Create(MedidaDTO medidaDTO)
        {
            try
            {
                BLL.Inserir(medidaDTO);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Medida/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Medida/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Medida/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Medida/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
