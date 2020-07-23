using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class PizzaFakeDb : FakeDb<Pizza>
    {
        private static readonly Lazy<PizzaFakeDb> lazy = new Lazy<PizzaFakeDb>(() => new PizzaFakeDb());

        public static PizzaFakeDb Instance { get { return lazy.Value; } }
        
        private static int idSeq = 1;
        private PizzaFakeDb() : base(new List<Pizza>(), idSeq) { }
    }
}
