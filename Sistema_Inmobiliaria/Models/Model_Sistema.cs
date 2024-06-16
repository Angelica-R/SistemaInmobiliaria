using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Sistema_Inmobiliaria.Models
{
    public partial class Model_Sistema : DbContext
    {
        public Model_Sistema()
            : base("name=Model_Sistema")
        {
        }

        public virtual DbSet<categoria> categoria { get; set; }
        public virtual DbSet<citas> citas { get; set; }
        public virtual DbSet<clientes> clientes { get; set; }
        public virtual DbSet<guias_programadas> guias_programadas { get; set; }
        public virtual DbSet<inmuebles> inmuebles { get; set; }
        public virtual DbSet<locales> locales { get; set; }
        public virtual DbSet<propietarios> propietarios { get; set; }
        public virtual DbSet<roles> roles { get; set; }
        public virtual DbSet<usuarios> usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<categoria>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<categoria>()
                .HasMany(e => e.inmuebles)
                .WithRequired(e => e.categoria)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<clientes>()
                .Property(e => e.cliDni)
                .IsUnicode(false);

            modelBuilder.Entity<clientes>()
                .Property(e => e.cliNombre)
                .IsUnicode(false);

            modelBuilder.Entity<clientes>()
                .Property(e => e.cliApellido)
                .IsUnicode(false);

            modelBuilder.Entity<clientes>()
                .Property(e => e.cliTelefono)
                .IsUnicode(false);

            modelBuilder.Entity<clientes>()
                .Property(e => e.cliEmail)
                .IsUnicode(false);

            modelBuilder.Entity<clientes>()
                .Property(e => e.cliClave)
                .IsUnicode(false);

            modelBuilder.Entity<clientes>()
                .HasMany(e => e.citas)
                .WithRequired(e => e.clientes)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<guias_programadas>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<guias_programadas>()
                .Property(e => e.telefono)
                .IsUnicode(false);

            modelBuilder.Entity<guias_programadas>()
                .Property(e => e.correo)
                .IsUnicode(false);

            modelBuilder.Entity<guias_programadas>()
                .Property(e => e.mensaje)
                .IsUnicode(false);

            modelBuilder.Entity<inmuebles>()
                .Property(e => e.titulo)
                .IsUnicode(false);

            modelBuilder.Entity<inmuebles>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<inmuebles>()
                .Property(e => e.precio)
                .IsUnicode(false);

            modelBuilder.Entity<inmuebles>()
                .Property(e => e.imagen)
                .IsUnicode(false);

            modelBuilder.Entity<inmuebles>()
                .Property(e => e.ruta)
                .IsUnicode(false);

            modelBuilder.Entity<inmuebles>()
                .HasMany(e => e.guias_programadas)
                .WithRequired(e => e.inmuebles)
                .HasForeignKey(e => e.inmueble)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<locales>()
                .Property(e => e.localNombre)
                .IsUnicode(false);

            modelBuilder.Entity<locales>()
                .Property(e => e.localDireccion)
                .IsUnicode(false);

            modelBuilder.Entity<locales>()
                .HasMany(e => e.citas)
                .WithRequired(e => e.locales)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<propietarios>()
                .Property(e => e.propnombre)
                .IsUnicode(false);

            modelBuilder.Entity<propietarios>()
                .Property(e => e.propapellido)
                .IsUnicode(false);

            modelBuilder.Entity<propietarios>()
                .Property(e => e.propdni)
                .IsUnicode(false);

            modelBuilder.Entity<propietarios>()
                .Property(e => e.proptelefono)
                .IsUnicode(false);

            modelBuilder.Entity<propietarios>()
                .Property(e => e.propemail)
                .IsUnicode(false);

            modelBuilder.Entity<roles>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<roles>()
                .HasMany(e => e.usuarios)
                .WithRequired(e => e.roles)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<usuarios>()
                .Property(e => e.dni)
                .IsUnicode(false);

            modelBuilder.Entity<usuarios>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<usuarios>()
                .Property(e => e.apellido)
                .IsUnicode(false);

            modelBuilder.Entity<usuarios>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<usuarios>()
                .Property(e => e.clave)
                .IsUnicode(false);

            modelBuilder.Entity<usuarios>()
                .Property(e => e.direccion)
                .IsUnicode(false);

            modelBuilder.Entity<usuarios>()
                .Property(e => e.telefono)
                .IsUnicode(false);

            modelBuilder.Entity<usuarios>()
                .Property(e => e.foto)
                .IsUnicode(false);
        }
    }
}
