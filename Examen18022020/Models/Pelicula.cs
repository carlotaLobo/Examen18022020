using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Examen18022020.Models
{
    [Table("Peliculas")]
    public class Pelicula
    {
        [Key]
        [Column("Idpelicula")]
        public int Id { get; set; }
        [Column("IdDistribuidor")]
        public int Iddistribuidor { get; set; }
        [Column("idgenero")]
        public int Idgenero { get; set; }
        [Column("titulo")]
        public String Titulo { get; set; }
        [Column("argumento")]
        public String Argumento { get; set; }
        [Column("foto")]
        public String Foto { get; set; }
        [Column("fecha_estreno")]
        public DateTime Fechaestreno { get; set; }
        [Column("actores")]
        public String Actores { get; set; }
        [Column("director")]
        public String Director { get; set; }
        [Column("duracion")]
        public int Duracion { get; set; }
        [Column("precio")]
        public int Precio { get; set; }

    }
}
