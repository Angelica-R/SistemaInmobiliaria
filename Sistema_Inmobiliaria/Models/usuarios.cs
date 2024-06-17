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

        public virtual roles roles { get; set; }



        //Implementacion de metodos

        //METODO LISTAR

        public List<usuarios> Listar()
        {
            var Query = new List<usuarios>();
            try
            {
                using (var db = new Model_Sistema())
                {
                    Query = db.usuarios.Include("roles").ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Query;
        }

        //METODO OBTENER
        public usuarios Obtener(int id = 0)
        {
            var Query = new usuarios();
            try
            {

                using (var db = new Model_Sistema())
                {
                    Query = db.usuarios.Include("roles").
                            Where(x => x.codusuario == id).
                            SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Query;
        }


        //METODO BUSCAR
        public List<usuarios> Buscar(string nombre) //Devuelve una coleccion de objetos
        {

            //var resultados = new List<Usuarios>();

            //if (!string.IsNullOrEmpty(rol))
            //{
            //    resultados = resultados.Where(x => x.Roles.Nombre_Rol == rol).ToList();
            //}

            //if (!string.IsNullOrEmpty(nombre))
            //{
            //    resultados = resultados.Where(x => x.Nombre.Contains(nombre)).ToList();
            //}

            //return resultados;

            var Query = new List<usuarios>();

            try
            {
                using (var db = new Model_Sistema())

                {
                    Query = db.usuarios.Include("roles").
                        Where(x => x.nombre.Contains(nombre) || x.roles.descripcion.Contains(nombre)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return Query;
        }


        //METODO GUARDAR
        public void Guardar()
        {
            try
            {
                using (var db = new Model_Sistema())
                {
                    if (this.codusuario > 0) //el objeto existe Modificar
                    {
                        db.Entry(this).State = EntityState.Modified;
                    }
                    else //Nuevo objeto Agregar
                    {
                        db.Entry(this).State = EntityState.Added;
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //METODO ELIMINAR
        public void Eliminar()
        {
            try
            {
                using (var db = new Model_Sistema())
                {
                    db.Entry(this).State = EntityState.Deleted;
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
