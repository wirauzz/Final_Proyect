using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurante_Proyecto.Models
{
    public class Dish
    {
        public int? Id { get; set; }
        [Required]
        public string  Name { get; set; }
        [StringLength(40,ErrorMessage ="Earth does not have so long resources")]
        public string  MainIngredient { get; set; }
        [Required]
        public string  Nationality { get; set; }
        public double Cost { get; set; }
        public string Size { get; set; }
        public int? RestaurantId { get; set; }
        public string ImagePath { get; set; }
    }
}
