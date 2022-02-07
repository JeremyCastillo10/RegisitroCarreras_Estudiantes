using System;
using RegistroEstudiantes.Entidades;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace RegistroEstudiantes.BLL
{
    public class EstudiantesBLL
    {

        public static bool Existe(int EstudianteId)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Estudiantes.Any(l => l.EstudianteId == EstudianteId);
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

        public static bool Guardar(Estudiantes Estudiantes)
        {
            if (!Existe(Estudiantes.EstudianteId))
                return Insertar(Estudiantes);
            else
                return Modificar(Estudiantes);

        }

        private static bool Insertar(Estudiantes estudiante)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                contexto.Estudiantes.Add(estudiante);
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

        private static bool Modificar(Estudiantes estudiante)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                contexto.Entry(estudiante).State = EntityState.Modified;
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

        public static bool Eliminar(int EstudianteId)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                var estudiante = contexto.Estudiantes.Find(EstudianteId);
                if (estudiante != null)
                {
                    contexto.Estudiantes.Remove(estudiante);
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

        public static Estudiantes? Buscar(int EstudianteId)
        {
            Contexto contexto = new Contexto();
            Estudiantes? estudiante;
            try
            {
                estudiante = contexto.Estudiantes.Find(EstudianteId);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return estudiante;
        }

        public static List<Estudiantes> GetList(Expression<Func<Estudiantes, bool>> criterio)
        {
            Contexto contexto = new Contexto();
            List<Estudiantes> lista = new List<Estudiantes>();
            try
            {
                lista = contexto.Estudiantes.Where(criterio).ToList();
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
        public static bool BuscarEstudiante(int Id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Estudiantes.Any(e => e.EstudianteId == Id);
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