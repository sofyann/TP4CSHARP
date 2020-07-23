using Database;
using Entities;
using Pizzas.Models;
using Pizzas.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pizzas.Controllers
{
    public class PizzaController : Controller
    {
        // GET: Pizza
        public ActionResult Index()
        {
            List<Pizza> pizzas = PizzaFakeDb.Instance.GetAll(); 
            return View(pizzas);
        }

        // GET: Pizza/Details/5
        public ActionResult Details(int id)
        {
            PizzaViewModel pvm = new PizzaViewModelManager().getPVM(id);
            return View(pvm);
        }

        // GET: Pizza/Create
        public ActionResult Create()
        {
            return View(new PizzaViewModelManager().getPVM());
        }

        // POST: Pizza/Create
        [HttpPost]
        public ActionResult Create(PizzaViewModel pvm)
        {
            try
            {
                new PizzaViewModelManager().savePVM(pvm);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pizza/Edit/5
        public ActionResult Edit(int id)
        {
            return View(new PizzaViewModelManager().getPVM(id));
        }

        // POST: Pizza/Edit/5
        [HttpPost]
        public ActionResult Edit(PizzaViewModel pvm)
        {
            try
            {
                new PizzaViewModelManager().savePVM(pvm);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pizza/Delete/5
        public ActionResult Delete(int id)
        {
            Pizza pizza = PizzaFakeDb.Instance.Get(id);
            if (pizza == null)
            {
                return RedirectToAction("Index");
            } else
            {
                return View(pizza);
            }
        }

        // POST: Pizza/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                PizzaFakeDb.Instance.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
