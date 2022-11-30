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
    public class AlunoController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Aluno
        public ActionResult Index()
        {
            var alunos = db.Alunos.Include(a => a.Curso);
            return View(alunos.ToList());
        }

        //GET: AlunoModels/Create 
        public ActionResult Create()
        {
            ViewBag.CursoId = new SelectList(db.Cursos, "Id", "Curso");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AlunoModel alunoModel)
        {
            if(ModelState.IsValid)
            {
                db.Alunos.Add(alunoModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CursoId = new SelectList(db.Cursos, "Id", "Curso", alunoModel.CursoId);
            return View(alunoModel);
        }

        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlunoModel alunoModel = db.Alunos.Find(id);
            if(alunoModel == null)
            {
                return HttpNotFound();
            }
            return View(alunoModel);
        }

        public ActionResult Edit (int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlunoModel alunoModel = db.Alunos.Find(id);
            if(alunoModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.CursoId = new SelectList(db.Cursos, "Id", "Curso", alunoModel.CursoId);
            return View(alunoModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AlunoModel alunoModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alunoModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CursoId = new SelectList(db.Cursos, "Id", "Curso", alunoModel.CursoId);
            return View(alunoModel);
        }

        public ActionResult Delete(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlunoModel alunoModel = db.Alunos.Find(id);
            if(alunoModel == null)
            {
                return HttpNotFound();
            }
            return View(alunoModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AlunoModel alunoModel = db.Alunos.Find(id);
            db.Alunos.Remove(alunoModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        
    }
}