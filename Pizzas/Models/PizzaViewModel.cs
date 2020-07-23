using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pizzas.Models
{
    public class PizzaViewModel
    {
        public Pizza Pizza { get; set; }
        public List<Pate> Pates { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public int IdPate { get; set; }
        public List<int> IdIngredients { get; set; }
    }
}