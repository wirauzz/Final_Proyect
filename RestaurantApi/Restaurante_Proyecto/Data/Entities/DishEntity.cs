using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurante_Proyecto.Data.Entities
{
    public class DishEntity
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string MainIngredient { get; set; }
        [Required]
        public string Nationality { get; set; }
        public double Cost { get; set; }
        public string Size { get; set; }
        public string ImagePath { get; set; }
        [ForeignKey("RestaurantId")]
        public virtual RestaurantEntity Restaurant { get; set; }
    }
}
