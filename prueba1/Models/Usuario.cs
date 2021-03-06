﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace prueba1.Models
{
    public class Usuario
    {
        [Key]
        public string mail { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public bool activo { get; set; }
        public bool administrador { get; set; }

        // Relaciones
        public List<Telefono> telefonos { get; set; }
        public List<Evento> eventos { get; set; }

        // Contructor
        public Usuario(){}

    }
}