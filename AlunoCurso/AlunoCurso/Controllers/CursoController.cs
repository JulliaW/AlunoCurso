using AlunoCurso.Context;
using AlunoCurso.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AlunoCurso.Controllers
{
    public class CursoController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Curso
        public ActionResult Index()
        {
            return View(db.Cursos.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CursoModel cursoModel)
        {
            if (ModelState.IsValid)
            {
                db.Cursos.Add(cursoModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cursoModel);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CursoModel cursoModel = db.Cursos.Find(id);
            if (cursoModel == null)
            {
                return HttpNotFound();
            }
            return View(cursoModel);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CursoModel cursoModel = db.Cursos.Find(id);
            if (cursoModel == null)
            {
                return HttpNotFound();
            }
            return View(cursoModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CursoModel cursoModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cursoModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cursoModel);

        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CursoModel cursoModel = db.Cursos.Find(id);
            if (cursoModel == null)
            {
                return HttpNotFound();
            }
            return View(cursoModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CursoModel cursoModel = db.Cursos.Find(id);
            db.Entry(cursoModel).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}