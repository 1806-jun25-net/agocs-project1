using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExpertPizzaWebApp.Models
{
    public class Pizza
    {

        public int PizzaId { get; set; }
        [Range(0, 1)]
        public int HasHotsauce { get; set; }
        [Range(0, 1)]
        public int HasHam { get; set; }
        [Range(0, 1)]
        public int HasSausage { get; set; }
        [Range(0, 1)]
        public int HasPepperoni { get; set; }
        public int IngredientCount { get; set; }
        [Range(1, 12)]
        public int PizzaCount { get; set; }
        public double? Price { get; set; }

    }
}
