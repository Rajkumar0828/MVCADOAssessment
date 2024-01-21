using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCADOAssessment.Models;
using MVCADOAssessment.DBAccessLayer;
namespace MVCADOAssessment.Controllers
{
    public class TrainingController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View(DbConnectionLayer.GetAllTraining());
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View(DbConnectionLayer.GetIndividualTraining(id));
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Training TrainingInfo)
        {
            try
            {
                if (DbConnectionLayer.Add(TrainingInfo))
                {
                    return RedirectToAction("Index");
                };
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View(DbConnectionLayer.GetIndividualTraining(id));
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Training TrainingInfo)
        {
            try
            {
                if (DbConnectionLayer.Update(TrainingInfo))
                {
                    return RedirectToAction("Index");

                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {

            return View(DbConnectionLayer.GetIndividualTraining(id));
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Training TrainingInfo)
        {
            try
            {
                if (DbConnectionLayer.Delete(id))
                {
                    return RedirectToAction("Index");

                }
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");

            }
        }
    }
}
