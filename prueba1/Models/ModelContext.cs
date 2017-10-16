using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace prueba1.Models
{
    public class ModelContext : DbContext
    {
        public ModelContext() : base(Properties.Settings.Default.con) {}

        public DbSet<Usuario> usuarios { get; set; }
        public DbSet<Telefono> telefonos { get; set; }
        public DbSet<Evento> eventos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().ToTable("Usuarios");
            modelBuilder.Entity<Usuario>().HasKey(x => x.mail);

        }
           
    }
}