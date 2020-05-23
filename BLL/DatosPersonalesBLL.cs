using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Tarea2_RegistroCompleto.DAL;
using Tarea2_RegistroCompleto.Entidades;

namespace Tarea2_RegistroCompleto.BLL
{
    public class DatosPersonalesBLL
    {
        /// <summary>
        /// Permite insertar o modificar una entidad en la base de datos
        /// </summary>
        /// <param name="datospersonales">La entidad que se desea guardar</param> 
        public static bool Guardar(DatosPersonales datospersonales)
        {
            if (!Existe(datospersonales.DatosPersonalesId))//si no existe insertamos
                return Insertar(datospersonales);
            else
                return Modificar(datospersonales);
        }

        /// <summary>
        /// Permite insertar una entidad en la base de datos
        /// </summary>
        /// <param name="datospersonales">La entidad que se desea guardar</param>
        private static bool Insertar(DatosPersonales datospersonales)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                //Agregar la entidad que se desea insertar al contexto
                contexto.DatosPersonales.Add(datospersonales);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        /// <summary>
        /// Permite modificar una entidad en la base de datos
        /// </summary>
        /// <param name="datospersonales">La entidad que se desea modificar</param> 
        public static bool Modificar(DatosPersonales datospersonales)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                //marcar la entidad como modificada para que el contexto sepa como proceder
                contexto.Entry(datospersonales).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        /// <summary>
        /// Permite eliminar una entidad de la base de datos
        /// </summary>
        /// <param name="id">El Id de la entidad que se desea eliminar</param> 
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                //buscar la entidad que se desea eliminar
                var datospersonales = contexto.DatosPersonales.Find(id);

                if (datospersonales != null)
                {
                    contexto.DatosPersonales.Remove(datospersonales);//remover la entidad
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        /// <summary>
        /// Permite buscar una entidad en la base de datos
        /// </summary>
        /// <param name="id">El Id de la entidad que se desea buscar</param> 
        public static DatosPersonales Buscar(int id)
        {
            Contexto contexto = new Contexto();
            DatosPersonales datospersonales;

            try
            {
                datospersonales = contexto.DatosPersonales.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return datospersonales;
        }

        /// <summary>
        /// Permite obtener una lista filtrada por un criterio de busqueda
        /// </summary>
        /// <param name="criterio">La expresión que define el criterio de busqueda</param>
        /// <returns></returns>
        public static List<DatosPersonales> GetList(Expression<Func<DatosPersonales, bool>> criterio)
        {
            List<DatosPersonales> lista = new List<DatosPersonales>();
            Contexto contexto = new Contexto();
            try
            {
                //obtener la lista y filtrarla según el criterio recibido por parametro.
                lista = contexto.DatosPersonales.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.DatosPersonales
                    .Any(d => d.DatosPersonalesId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;
        }

        public static List<DatosPersonales> GetEstudiante()
        {
            List<DatosPersonales> lista = new List<DatosPersonales>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.DatosPersonales.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }
    }
}