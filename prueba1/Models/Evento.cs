using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prueba1.Models
{
    public class Evento
    {
        [Key, Column(Order = 0)]
        public string tipo { get; set; }
        [Key, Column(Order = 1)]
        public DateTime fecha { get; set; }

    }
}