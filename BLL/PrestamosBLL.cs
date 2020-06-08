using System;
using System.Collections.Generic;
using System.Text;
//Agregar estos using.
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using JL_RegistroCompleto.DAL;
using JL_RegistroCompleto.Entidades;

namespace JL_RegistroCompleto.BLL
{
    public class PrestamosBLL
    {
    //——————————————————————————————————————————————[ GUARDAR ]——————————————————————————————————————————————
        // Permite insertar o modificar una entidad en la base de datos
        /// <param name="prestamos">La entidad que se desea guardar</param>
        public static bool Guardar(Prestamos prestamos)
        {
            if (!Existe(prestamos.PrestamoId))//si no existe insertamos
                return Insertar(prestamos);
            else
                return Modificar(prestamos);
        }
    //——————————————————————————————————————————————[ INSERTAR ]——————————————————————————————————————————————
        // Permite insertar una entidad en la base de datos
        /// <param name="prestamos">La entidad que se desea guardar</param>
        private static bool Insertar(Prestamos prestamos)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
                try
                {
                    //Agregar la entidad que se desea insertar al contexto
                    contexto.Prestamos.Add(prestamos);
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
     //——————————————————————————————————————————————[ MODIFICAR ]——————————————————————————————————————————————
        // Permite modificar una entidad en la base de datos
        /// <param name="prestamos">La entidad que se desea modificar</param> 
        public static bool Modificar(Prestamos prestamos)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
                try
                {
                    //marcar la entidad como modificada para que el contexto sepa como proceder
                    contexto.Entry(prestamos).State = EntityState.Modified;
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
    //——————————————————————————————————————————————[ ELIMINAR ]——————————————————————————————————————————————
        // Permite eliminar una entidad de la base de datos
        /// <param name="id">El Id de la entidad que se desea eliminar</param> 
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
                try
                {
                    //buscar la entidad que se desea eliminar
                    var prestamos = contexto.Prestamos.Find(id);
                        if (prestamos != null)
                        {
                            contexto.Prestamos.Remove(prestamos);//remover la entidad
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
    //——————————————————————————————————————————————[ BUSCAR ]——————————————————————————————————————————————
        // Permite buscar una entidad en la base de datos
        /// <param name="id">El Id de la entidad que se desea buscar</param> 
        public static Prestamos Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Prestamos prestamos;
                try
                {
                    prestamos = contexto.Prestamos.Find(id);
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    contexto.Dispose();
                }
            return prestamos;
        }
    //——————————————————————————————————————————————[ GETLIST ]——————————————————————————————————————————————
        // Permite obtener una lista filtrada por un criterio de busqueda
        /// <param name="criterio">La expresión que define el criterio de busqueda</param>
        /// <returns></returns>
        public static List<Prestamos> GetList(Expression<Func<Prestamos, bool>> criterio)
        {
            List<Prestamos> lista = new List<Prestamos>();
            Contexto contexto = new Contexto();
                try
                {
                    //obtener la lista y filtrarla según el criterio recibido por parametro.
                    lista = contexto.Prestamos.Where(criterio).ToList();
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
    //——————————————————————————————————————————————[ EXISTE ]——————————————————————————————————————————————
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;
                try
                {
                    encontrado = contexto.Prestamos.Any(d => d.PrestamoId == id);
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
    //——————————————————————————————————————————————[ GET "Nombre de la clase" ]——————————————————————————————————————————————
        public static List<Prestamos> GetPrestamos()
        {
            List<Prestamos> lista = new List<Prestamos>();
            Contexto contexto = new Contexto();
                try
                {
                    lista = contexto.Prestamos.ToList();
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