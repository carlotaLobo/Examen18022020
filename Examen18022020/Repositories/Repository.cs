using Examen18022020.Data;
using Examen18022020.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen18022020.Repositories
{
    public class Repository : IRepository
    {
        Context context;
        public Repository(Context context)
        {
            this.context = context;
        }
        public List<Doctor> FindAllDoctores()
        {
            return this.context.Doctores.ToList();
        }

        public List<Genero> FindAllGeneros()
        {
            return this.context.Generos.ToList();
        }

        public List<Pelicula> FindAllPelicula()
        {
            return this.context.Peliculas.ToList();
        }

        public Doctor FindDoctorById(int id)
        {
            return this.context.Doctores.Find(id);
        }

        public List<Pelicula> FindPeliculaByGenero(int id)
        {
            return this.context.Peliculas.Where(p => p.Idgenero == id).ToList();
        }

        public Pelicula FindPeliculaById(int id)
        {
            try
            {
            return this.context.Peliculas.Where(p => p.Id == id).FirstOrDefault();

            }catch(Exception e)
            {
                return null;
            }
        }

        public Doctor LogIn(int numeroDoctor, string apellido)
        {
            return (this.context.Doctores.Where(d => d.Apellido == apellido &&
            d.NumeroDoctor == numeroDoctor)).FirstOrDefault();
        }

        public List<Pelicula> PaginacionPelisGenero(int idgenero, int posicion, ref int registros)
        {
            String sql = "PAGINACIONFILTRADO @POSICION, @REGISTROS OUT, @GENERO";

            SqlParameter pamposicion = new SqlParameter("@POSICION", posicion);
            SqlParameter pamidgenero = new SqlParameter("@GENERO", idgenero);
            SqlParameter pamidregistro = new SqlParameter("@REGISTROS", -1);
            pamidregistro.Direction = System.Data.ParameterDirection.Output;

            List<Pelicula> peliculas= this.context.Peliculas
                .FromSqlRaw(sql,pamposicion, pamidregistro, pamidgenero).ToList();
            int cantidad = Convert.ToInt32(pamidregistro.Value);
            registros = cantidad;

            return peliculas;
        }

        public List<Pelicula> PaginacionTodo(int posicion, ref int registros)
        {
            String sql = "PAGINACIONGRUPO @POSICION, @REGISTROS OUT";

            SqlParameter pamposicion = new SqlParameter("@POSICION", posicion);
            SqlParameter pamidregistro = new SqlParameter("@REGISTROS", -1);
            pamidregistro.Direction = System.Data.ParameterDirection.Output;
            List<Pelicula> peliculas = this.context.Peliculas
                 .FromSqlRaw(sql, pamposicion, pamidregistro).ToList();
            int cantidad = Convert.ToInt32(pamidregistro.Value);
            registros = cantidad;

            return peliculas;
        }
    }
}
