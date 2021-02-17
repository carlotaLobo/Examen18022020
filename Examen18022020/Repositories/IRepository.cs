using Examen18022020.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
#region PAGINACION

//ALTER PROCEDURE PAGINACIONFILTRADO
//(@POSICION INT, @REGISTROS INT OUT, @GENERO NVARCHAR(30))
//AS
//    SELECT @REGISTROS= COUNT(IdPelicula) FROM Peliculas WHERE IdGenero=@GENERO

//	SELECT * FROM ( 
//	SELECT ROW_NUMBER() OVER(ORDER BY IDPELICULA)

//    AS POSICION, Peliculas.* FROM Peliculas
//	WHERE IDGENERO =@GENERO)  CONSULTA
//    WHERE POSICION >= @POSICION AND POSICION < (@POSICION + 3)

//GO


//--------------------------------------------------------------------------

//CREATE PROCEDURE PAGINACION1
//(@POSICION INT, @REGISTROS INT OUT, @GENERO NVARCHAR(30))
//AS
//	SELECT @REGISTROS= COUNT(IdPelicula) FROM Peliculas

//	SELECT * FROM ( 
//	SELECT ROW_NUMBER() OVER(ORDER BY IDPELICULA)
//	AS POSICION, Peliculas.* FROM Peliculas)  
//	CONSULTA
//	WHERE POSICION = @POSICION 
//GO

//---------------------------------------------------------------------

//CREATE PROCEDURE PAGINACIONGRUPO
//(@POSICION INT, @REGISTROS INT OUT)
//AS
//    SELECT @REGISTROS= COUNT(IdPelicula) FROM Peliculas

//	SELECT * FROM ( 
//	SELECT ROW_NUMBER() OVER(ORDER BY IDPELICULA)

//    AS POSICION, Peliculas.* FROM Peliculas)  
//	CONSULTA
//    WHERE POSICION >= @POSICION AND POSICION <(@POSICION + 3)
//GO

//-------------------------------------------------------------------
//CREATE VIEW REGISTROSPELICULAS
//AS
//SELECT CAST(ISNULL(ROW_NUMBER() OVER(ORDER BY IDPELICULA), 0) AS INT) AS POSICION,
//IDPELICULA FROM Peliculas 
//GO

#endregion
namespace Examen18022020.Repositories
{
    public interface IRepository
    {
        List<Doctor> FindAllDoctores();
        Doctor FindDoctorById(int id);
        List<Pelicula> FindAllPelicula();
        List<Pelicula> FindPeliculaByGenero(int id);
        Pelicula FindPeliculaById(int id);
        List<Genero> FindAllGeneros();
        Doctor LogIn(int numeroDoctor, String apellido);
        List<Pelicula> PaginacionPelisGenero(int idgenero, int posicion, ref int registros);
        List<Pelicula> PaginacionTodo(int posicion, ref int registros);
    }
}
