using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvc4jumpstart.Models
{
    public class Person
    {
        public int PersonId { get; set; }   

        [Required(ErrorMessage = "Please enter a name.")]
        public string Name { get; set; }

        [Range(0,400)]
        public int Height { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
    }
}