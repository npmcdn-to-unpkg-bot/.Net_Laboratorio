using BLayer.SuperAdmin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperAdmin.Controllers
{
    public class JuegosController : Controller
    {
        // GET: ListarJuegos
        public ActionResult Listar()
        {
            SuperAdminController Sa = new SuperAdminController();
            return View(Sa.ListarJuegos());
        }

        // GET: ListarJuegos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ListarJuegos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ListarJuegos/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ListarJuegos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ListarJuegos/Edit/5
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

        // GET: ListarJuegos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ListarJuegos/Delete/5
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
