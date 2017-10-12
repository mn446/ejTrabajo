using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace prueba1.Models
{
    public class Telefono
    {
        [Key]
        public int numero { get; set; }
        public string tipo { get; set; }

        // Contructor
        public Telefono(){}
    }
}