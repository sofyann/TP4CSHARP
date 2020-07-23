using Database;
using Entities;
using Pizzas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pizzas.Utils
{
    public class PizzaViewModelManager
    {

        public PizzaViewModel getPVM()
        {
            PizzaViewModel pvm = new PizzaViewModel();
            pvm = populatePVM(pvm);
            return pvm;
        }

        public PizzaViewModel getPVM(int id)
        {
            PizzaViewModel pvm = getPVM();
            pvm.Pizza = PizzaFakeDb.Instance.Get(id);
            pvm.IdIngredients = pvm.Pizza.Ingredients.Select(i => i.Id).ToList();
            pvm.IdPate = pvm.Pizza.Pate.Id;
            return pvm;
        }

        public void savePVM(PizzaViewModel pvm)
        {
            pvm = populatePVM(pvm);
            pvm.Pizza.Ingredients = pvm.Ingredients.Where(i => pvm.IdIngredients.Contains(i.Id)).Select(i => i).ToList();
            pvm.Pizza.Pate = pvm.Pates.Where(i => i.Id == pvm.IdPate).Select(i => i).FirstOrDefault();
            PizzaFakeDb.Instance.Set(pvm.Pizza);
        }

        private PizzaViewModel populatePVM(PizzaViewModel pvm)
        {
            pvm.Pates = PateFakeDb.Instance.GetAll();
            pvm.Ingredients = IngredientFakeDb.Instance.GetAll();
            return pvm;
        }
    }
}