using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class PateFakeDb : FakeDb<Pate>
    {
        private static readonly Lazy<PateFakeDb> lazy = new Lazy<PateFakeDb>(() => new PateFakeDb());

        public static PateFakeDb Instance { get { return lazy.Value; } }

        private PateFakeDb() : 
            base (new List<Pate>
            {
                new Pate{ Id=1,Nom="Pate fine, base crême"},
                new Pate{ Id=2,Nom="Pate fine, base tomate"},
                new Pate{ Id=3,Nom="Pate épaisse, base crême"},
                new Pate{ Id=4,Nom="Pate épaisse, base tomate"}
            }) { }
    }
}
