namespace Sistema_Inmobiliaria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class roles
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public roles()
        {
            usuarios = new HashSet<usuarios>();
        }

        [Key]
        public int codrol { get; set; }

        [StringLength(25)]
        public string descripcion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<usuarios> usuarios { get; set; }



        //Implementacion de metodos

        //METODO LISTAR

        public List<roles> Listar() //Devuelve una coleccion de objetos
        {
            var Query = new List<roles>();
            try
            {
                using (var db = new Model_Sistema())
                {
                    Query = db.roles.ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return Query;
        }

        //METODO OBTENER
        public roles Obtener(int id)
        {
            var Query = new roles();
            try
            {

                using (var db = new Model_Sistema())
                {
                    Query = db.roles.
                            Where(x => x.codrol == id).
                            SingleOrDefault();
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
                    if (this.codrol > 0) //el objeto existe Modificar
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
