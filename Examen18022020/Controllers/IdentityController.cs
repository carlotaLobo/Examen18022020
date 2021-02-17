using Examen18022020.Models;
using Examen18022020.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Examen18022020.Controllers
{
    public class IdentityController : Controller
    {
        IRepository repo;
        public IdentityController(IRepository repo)
        {
            this.repo = repo;
        }
        public IActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(int numeroDoctor, String apellido)
        {
            Doctor doctor = this.repo.LogIn(numeroDoctor, apellido);
            if(doctor == null)
            {
                return View();
            }

            ClaimsIdentity identity = new ClaimsIdentity(
                CookieAuthenticationDefaults.AuthenticationScheme,
                ClaimTypes.Name, ClaimTypes.Role
                );
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, doctor.NumeroDoctor.ToString()));
            identity.AddClaim(new Claim(ClaimTypes.Name, doctor.Apellido));
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme, principal, 
                new AuthenticationProperties
                {
                    IsPersistent= true,
                    ExpiresUtc= DateTime.Now.AddMinutes(15)
                }
                );
            String action = TempData["action"].ToString();
            String controller = TempData["controller"].ToString();

            return RedirectToAction(action, controller);
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("index", "home");
        }
    }
}
