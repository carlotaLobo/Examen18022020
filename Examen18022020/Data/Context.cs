using Examen18022020.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen18022020.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context>options) : base(options) { }
        public DbSet<Doctor> Doctores { get; set; }
        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<Genero> Generos { get; set; }
    }
}
