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
    public class ExtrasBLL ///Temporal
    {
        public static bool Guardar(Extras extras)
        {
            if (!Existe(extras.ExtraId))
                return Insertar(extras);
            else
                return Modificar(extras);
        }
        /// <summary>
        /// Permite guardar una entidad en la base de datos
        /// </summary>
        /// <param name="extras">La entidad que se desea guardar</param>
        private static bool Insertar(Extras extras)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                //Agregar la entidad que se desea insertar al contexto
                contexto.Extras.Add(extras);
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
        /// <param name="extras">La entidad que se desea modificar</param>
        private static bool Modificar(Extras extras)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                //marcar la entidad como modificada para que el contexto sepa como proceder
                contexto.Entry(extras).State = EntityState.Modified;
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
                var extras = ExtrasBLL.Buscar(id);

                if (extras != null)
                {
                    contexto.Extras.Remove(extras); //remover la entidad
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
        public static Extras Buscar(int id)
        {
            Extras extras = new Extras();
            Contexto contexto = new Contexto();

            try
            {
                extras = contexto.Extras.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return extras;
        }
        /// <summary>
        /// Permite obtener una lista filtrada por un criterio de busqueda
        /// </summary>
        /// <param name="criterio">La expresión que define el criterio de busqueda</param>
        /// <returns></returns>
        public static List<Extras> GetList(Expression<Func<Extras, bool>> criterio)
        {
            List<Extras> Lista = new List<Extras>();
            Contexto contexto = new Contexto();

            try
            {
                //obtener la lista y filtrarla según el criterio recibido por parametro.
                Lista = contexto.Extras.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return Lista;
        }
        /// <summary>
        /// Permite buscar si una entidad en la base de datos existe
        /// </summary>
        /// <param name="id">El Id de la entidad que se desea buscar</param>
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Extras.Any(e => e.ExtraId == id);
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
    }
}