namespace Sistema_Inmobiliaria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("usuarios")]
    public partial class usuarios
    {
        [Key]
        public int codusuario { get; set; }

        [Required]
        [StringLength(8)]
        public string dni { get; set; }

        [Required]
        [StringLength(30)]
        public string nombre { get; set; }

        [Required]
        [StringLength(30)]
        public string apellido { get; set; }

        [Required]
        [StringLength(50)]
        public string email { get; set; }

        [Required]
        [StringLength(10)]
        public string clave { get; set; }

        [Required]
        [StringLength(50)]
        public string direccion { get; set; }

        [Required]
        [StringLength(15)]
        public string telefono { get; set; }

        [StringLength(50)]
        public string foto { get; set; }

        public int codrol { get; set; }
        [ForeignKey("codrol")]
        public virtual roles roles { get; set; }



        // Métodos de Operaciones CRUD

        // Método para listar todos los usuarios
        //public List<usuarios> Listar()
        //{
        //    using (var db = new Model_Sistema())
        //    {
        //        return db.usuarios.Include("roles").ToList();
        //    }
        //}

        //public usuarios Obtener(int id)
        //{
        //    using (var db = new Model_Sistema())
        //    {
        //        return db.usuarios.Include("roles").SingleOrDefault(x => x.codusuario == id);
        //    }
        //}

        //public List<usuarios> Buscar(string nombre)
        //{
        //    using (var db = new Model_Sistema())
        //    {
        //        return db.usuarios.Include("roles").Where(x => x.nombre.Contains(nombre) || x.roles.descripcion.Contains(nombre)).ToList();
        //    }
        //}

        //public void Guardar()
        //{
        //    try
        //    {
        //        using (var db = new Model_Sistema())
        //        {
        //            if (this.codusuario > 0) // el objeto existe, modificar
        //            {
        //                db.Entry(this).State = EntityState.Modified;
        //            }
        //            else // nuevo objeto, agregar
        //            {
        //                db.usuarios.Add(this);
        //            }
        //            db.SaveChanges();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Diagnostics.Debug.WriteLine("Error: " + ex.Message);

        //        throw new Exception("Error al guardar el usuario: " + ex.Message);
        //    }
        //}


        //public void Eliminar()
        //{
        //    using (var db = new Model_Sistema())
        //    {
        //        db.Entry(this).State = EntityState.Deleted;
        //        db.SaveChanges();
        //    }
        //}



        //public List<usuarios> Listar()
        //{
        //    List<usuarios> Query = new List<usuarios>();
        //    try
        //    {
        //        using (var db = new Model_Sistema())
        //        {
        //            Query = db.usuarios.Include("roles").ToList();
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    return Query;
        //}

        //// Método para obtener un usuario por su ID
        //public usuarios Obtener(int id = 0)
        //{
        //    usuarios Query = new usuarios();
        //    try
        //    {
        //        using (var db = new Model_Sistema())
        //        {
        //            Query = db.usuarios.Include("roles")
        //                    .Where(x => x.codusuario == id)
        //                    .SingleOrDefault();
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    return Query;
        //}

        //// Método para buscar usuarios por nombre o descripción de rol
        //public List<usuarios> Buscar(string nombre)
        //{
        //    List<usuarios> Query = new List<usuarios>();
        //    try
        //    {
        //        using (var db = new Model_Sistema())
        //        {
        //            Query = db.usuarios.Include("roles")
        //                    .Where(x => x.nombre.Contains(nombre) || x.roles.descripcion.Contains(nombre))
        //                    .ToList();
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    return Query;
        //}

        //// Método para guardar un usuario (Insertar o Actualizar)
        //public void Guardar()
        //{
        //    try
        //    {
        //        using (var db = new Model_Sistema())
        //        {
        //            if (this.codusuario > 0) // el objeto existe, modificar
        //            {
        //                db.Entry(this).State = EntityState.Modified;
        //            }
        //            else // nuevo objeto, agregar
        //            {
        //                db.usuarios.Add(this);
        //            }
        //            db.SaveChanges();
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //// Método para eliminar un usuario
        //public void Eliminar()
        //{
        //    try
        //    {
        //        using (var db = new Model_Sistema())
        //        {
        //            db.Entry(this).State = EntityState.Deleted;
        //            db.SaveChanges();
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

    }
}
