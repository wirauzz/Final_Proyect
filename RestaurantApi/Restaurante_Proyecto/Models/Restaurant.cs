using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurante_Proyecto.Models
{
    public class Restaurant
    {
        public int? Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string FoodStyle { get; set; }
        [Required, StringLength(50, ErrorMessage ="We do not have streets such as the one you wrote")]
        public string Street { get; set; }
        [Range(1, 9999,ErrorMessage ="The city does not allow this")]
        public int AddressNumber { get; set; }
        public IEnumerable<Dish> Dishes { get; set; }
    }
}
