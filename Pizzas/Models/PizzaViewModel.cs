using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Pizzas.Models
{
    public class PizzaViewModel
    {
        public Pizza Pizza { get; set; }
        public List<Pate> Pates { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        
        [Required(ErrorMessage = "Vous devez sélectionner une pate.")]
        [Display(Name = "Pate")]
        public int IdPate { get; set; }

        [Required(ErrorMessage = "Vous devez sélectionner entre 2 et 5 ingrédients.")]
        //[MaxLength(5, ErrorMessage = "Vous devez sélectionner au minimum 2 ingrédients.")]
        //[MinLength(2, ErrorMessage = "Vous devez sélectionner au maximum 5 ingrédients.")]
        [Display(Name = "Ingrédients")]
        public List<int> IdIngredients { get; set; }
    }
}