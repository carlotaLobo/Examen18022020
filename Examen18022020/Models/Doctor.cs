using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Examen18022020.Models
{
    [Table("Doctor")]
    public class Doctor
    {
        [Key]
        [Column("Hospital_Cod")]
        public int CodigoHospital { get; set; }
        [Column("Doctor_no")]
        public int NumeroDoctor { get; set; }
        [Column("Apellido")]
        public String Apellido { get; set; }
        [Column("Especialidad")]
        public String Especialidad { get; set; }
        [Column("Salario")]
        public int Salario { get; set; }
    }
}
