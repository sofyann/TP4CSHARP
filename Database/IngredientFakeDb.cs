using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class IngredientFakeDb : FakeDb<Ingredient>
    {
        private static readonly Lazy<IngredientFakeDb> lazy = new Lazy<IngredientFakeDb>(() => new IngredientFakeDb());

        public static IngredientFakeDb Instance { get { return lazy.Value; } }

        private IngredientFakeDb() : 
            base (new List<Ingredient>()
            {
                new Ingredient{Id=1,Nom="Mozzarella"},
                new Ingredient{Id=2,Nom="Jambon"},
                new Ingredient{Id=3,Nom="Tomate"},
                new Ingredient{Id=4,Nom="Oignon"},
                new Ingredient{Id=5,Nom="Cheddar"},
                new Ingredient{Id=6,Nom="Saumon"},
                new Ingredient{Id=7,Nom="Champignon"},
                new Ingredient{Id=8,Nom="Poulet"}
            }) { }
    }
}
