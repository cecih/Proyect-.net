using MVC.RealEstate.WebUI.Models.Entities;
using MVC.RealEstate.WebUI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.RealEstate.WebUI.Controllers
{
    public abstract class ControllerBase<T> : Controller where T : EntityBase
    {
        protected IRepository<T> repository;

        public ControllerBase(IRepository<T> repository)
        {
            this.repository = repository;
        }
        //
        // GET: /User/

        public ActionResult Index()
        {
            return View(repository.GetAll().ToList());
        }

        //
        // GET: /User/Details/5

        public ActionResult Details(long id = 0)
        {
            T entity = GetEntityByID(id);
            if (entity == null)
            {
                return HttpNotFound();
            }
            return View(entity);
        }

        //
        // GET: /User/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /User/Create

        [HttpPost]
        public ActionResult Create(T entity)
        {
            if (ModelState.IsValid)
            {
                this.repository.Save(entity);
                return RedirectToAction("Index");
            }

            return View(entity);
        }

        ////
        //// GET: /User/Edit/5

        //public ActionResult Edit(long id = 0)
        //{
        //    T entity = GetEntityByID(id);
        //    if (entity == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(entity);
        //}

        ////
        //// POST: /User/Edit/5

        //public ActionResult Edit(T entity)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        this.repository.Save(entity);
        //        return RedirectToAction("Index");
        //    }
        //    return View(entity);
        //}

        //
        // GET: /User/Delete/5

        public ActionResult Delete(long id = 0)
        {
            T entity = GetEntityByID(id);
            if (entity == null)
            {
                return HttpNotFound();
            }
            return View(entity);
        }

        //
        // POST: /User/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {
            repository.Delete(id);
            return RedirectToAction("Index");
        }

        public abstract T GetEntityByID(long id);
    }
}