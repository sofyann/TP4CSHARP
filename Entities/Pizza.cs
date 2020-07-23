using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Pizza : Entity
    {
        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string Nom { get; set; }
        public Pate Pate { get; set; }
        public List<Ingredient> Ingredients { get; set; }

    }
}
