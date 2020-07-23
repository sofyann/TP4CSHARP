using Database;
using Entities;
using Microsoft.Ajax.Utilities;
using Pizzas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        public PizzaViewModel savePVM(PizzaViewModel pvm, ModelStateDictionary ModelState)
        {
            pvm = populatePVM(pvm);
            if (!ModelState.IsValid)
            {
                return pvm;
            }

            if (PizzaFakeDb.Instance.getPizzaByName(pvm.Pizza.Nom) != null)
            {
                ModelState.AddModelError("Pizza.Nom", "Il existe déjà une pizza possédant se nom");
            }
            
            var ingredients = pvm.Ingredients.Where(i => pvm.IdIngredients.Contains(i.Id)).Select(i => i).ToList();
            if (ingredients.Count() == 0)
            {
                ModelState.AddModelError("IdIngredients", "Vous devez sélectionner entre 2 et 5 ingrédients présents dans la liste.");
            }

            var pizzaWithSameIngredients = PizzaFakeDb.Instance.GetAll().FirstOrDefault(p => ingredients.All(p.Ingredients.Contains));
            if (pizzaWithSameIngredients != null)
            {
                ModelState.AddModelError("IdIngredients", $"La pizza \"{pizzaWithSameIngredients.Nom}\" possède déjà ces ingrédients.");
            } else
            {
                pvm.Pizza.Ingredients = ingredients;
            }

            var pate = pvm.Pates.Where(i => i.Id == pvm.IdPate).Select(i => i).FirstOrDefault();
            if (pate == null)
            {
                ModelState.AddModelError("idPate", "Vous devez une pate présente dans la liste.");
            } else
            {
                pvm.Pizza.Pate = pate;
            }

            if (!ModelState.IsValid)
            {
                return pvm;
            }

            PizzaFakeDb.Instance.Set(pvm.Pizza);
            return null;
        }

        private PizzaViewModel populatePVM(PizzaViewModel pvm)
        {
            pvm.Pates = PateFakeDb.Instance.GetAll();
            pvm.Ingredients = IngredientFakeDb.Instance.GetAll();
            return pvm;
        }
    }
}