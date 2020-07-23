using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Pate : Entity
    {
        [Required]
        [Display(Name = "Prénom")]
        [DataType(DataType.Text)]
        [StringLength(20, MinimumLength = 5)]
        public string Nom { get; set; }

    }
}
