using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExpertPizzaWebApp.Models
{
    public class User
    {

        public int UserId { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        public string City { get; set; }
        public DateTime Ordertime { get; set; } = DateTime.Now;

    }
}
