using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    // this is going to be our context model.
    // but we will write it.
    // should be a "POCO" "plain old CLR object"
    // need parameter-less contructor (usually default)
    // and public get-set properties
    public class User
    {
        //hidden property
        public int Id { get; set; }
        [Required] //cant submit username without a firstname
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
    }
}
