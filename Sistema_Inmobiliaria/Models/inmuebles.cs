namespace Sistema_Inmobiliaria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("inmuebles")]
    public partial class inmuebles
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public inmuebles()
        {
            guias_programadas = new HashSet<guias_programadas>();
        }

        [Key]
        public int idinmueble { get; set; }

        [Required]
        [StringLength(50)]
        public string titulo { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string descripcion { get; set; }

        [Required]
        [StringLength(20)]
        public string precio { get; set; }

        [Required]
        [StringLength(100)]
        public string imagen { get; set; }

        public int idcategoria { get; set; }

        [Required]
        [StringLength(200)]
        public string ruta { get; set; }

        public virtual categoria categoria { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<guias_programadas> guias_programadas { get; set; }



        //Implementacion de metodos

        //METODO LISTAR

        public List<inmuebles> Listar()
        {
            var Query = new List<inmuebles>();
            try
            {
                using (var db = new Model_Sistema())
                {
                    Query = db.inmuebles.Include("categoria").ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Query;
        }

        //METODO OBTENER
        public inmuebles Obtener(int id = 0)
        {
            var Query = new inmuebles();
            try
            {

                using (var db = new Model_Sistema())
                {
                    Query = db.inmuebles.Include("categoria").
                            Where(x => x.idinmueble == id).
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
        public List<inmuebles> Buscar(string nombre) //Devuelve una coleccion de objetos
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

            var Query = new List<inmuebles>();

            try
            {
                using (var db = new Model_Sistema())

                {
                    Query = db.inmuebles.Include("categoria").
                        Where(x => x.titulo.Contains(nombre) || x.categoria.descripcion.Contains(nombre)).ToList();
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
                    if (this.idinmueble > 0) //el objeto existe Modificar
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
