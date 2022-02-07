using System;
using RegistroCarreras.Entidades;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace RegistroCarreras.BLL
{
    public class CarrerasBLL
    {

        public static bool Existe(int CarreraId)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Carreras.Any(l => l.CarreraId == CarreraId);
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

        public static bool Guardar(Carreras carreras)
        {
            if (!Existe(carreras.CarreraId))
                return Insertar(carreras);
            else
                return Modificar(carreras);

        }

        private static bool Insertar(Carreras carrera)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                contexto.Carreras.Add(carrera);
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

        private static bool Modificar(Carreras carrera)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                contexto.Entry(carrera).State = EntityState.Modified;
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

        public static bool Eliminar(int CarreraId)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                var carrera = contexto.Carreras.Find(CarreraId);
                if (carrera != null)
                {
                    contexto.Carreras.Remove(carrera);
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

        public static Carreras? Buscar(int CarreraId)
        {
            Contexto contexto = new Contexto();
            Carreras? carrera;
            try
            {
                carrera = contexto.Carreras.Find(CarreraId);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return carrera;
        }

        public static List<Carreras> GetList(Expression<Func<Carreras, bool>> criterio)
        {
            Contexto contexto = new Contexto();
            List<Carreras> lista = new List<Carreras>();
            try
            {
                lista = contexto.Carreras.Where(criterio).ToList();
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
        public static bool BuscarCarrera(string nombre)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Carreras.Any(e => e.Nombre == nombre);
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