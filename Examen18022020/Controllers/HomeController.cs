using Examen18022020.Extensions;
using Examen18022020.Filters;
using Examen18022020.Models;
using Examen18022020.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Examen18022020.Controllers
{
    public class HomeController : Controller
    {
        IRepository repository;
        ISession session => HttpContext.Session;
        public HomeController(IRepository repository)
        {
            this.repository = repository;
        }
        public IActionResult Index(int? id, int?posicion)
        {
            //si no hay filtrado
            if (id == null)
            {
                if(posicion == null)
                {
                    posicion = 1;
                }
                int registros = 0;
                List<Pelicula> pelis = this.repository.PaginacionTodo(posicion.Value, ref registros);
                ViewData["NUMEROREGISTROS"] = registros;
               
                return View(pelis);
            }
            else //si hay filtrado por genero
            {
                if (posicion == null)
                {
                    posicion = 1;
                }
                int registros = 0;
                List<Pelicula> pelis = this.repository.PaginacionPelisGenero(id.Value,posicion.Value, ref registros);
                ViewData["NUMEROREGISTROS"] = registros;
                ViewBag.genero = id;
                return View(pelis);
            }

        }
        public IActionResult Cesta(int id)
        {
            List<Cesta> listacesta = session.GetObject<List<Cesta>>("CESTA");
            List<Cesta> cestita = new List<Cesta>();
            Cesta cestanueva;
            Cesta cestaantes;

            Pelicula peli = this.repository.FindPeliculaById(id);

            cestanueva = new Cesta();
            cestanueva.IdPelicula = peli.Id;
            cestanueva.Precio = peli.Precio;
            cestita.Add(cestanueva);

            if (listacesta != null)
            {
                foreach (Cesta c in listacesta)
                {
                    cestaantes = new Cesta();
                    cestaantes.Precio = c.Precio;
                    cestaantes.IdPelicula = c.IdPelicula;
                    if (c.IdPelicula != cestanueva.IdPelicula)
                    {
                        cestita.Add(cestaantes);
                    }
                }
            }
            session.SetObject("CESTA", cestita);

            return RedirectToAction("detalles", peli);

        }
        public IActionResult Detalles(int id)
        {
            return View(this.repository.FindPeliculaById(id));
        }
        [AuthorizeUsuario]
        public IActionResult Comprar()
        {


            return View();
        }
        public IActionResult EliminaCesta()
        {
            session.Remove("CESTA");
            TempData["message"] = "COMPRA REALIZADA";

            return RedirectToAction("comprar");
        }

    }
}
