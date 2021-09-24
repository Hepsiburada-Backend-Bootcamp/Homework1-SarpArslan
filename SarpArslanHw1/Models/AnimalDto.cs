using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SarpArslanHw1.Models
{
    public class AnimalDto
    {
        [StringLength(4, ErrorMessage = "Please enter a valid type (Cat,Bird or Dog!"), MinLength(3)]
        public string type { get; set; }

        [StringLength(20, ErrorMessage = "Please enter a valid breed!")]
        public string breed { get; set; }
        public int age { get; set; }
    }
}
