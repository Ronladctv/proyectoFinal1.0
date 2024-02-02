using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using proyectoFinal.Models;
using System.Diagnostics;
using System.Security.Claims;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;

namespace proyectoFinal.Controllers
{
    // [Authorize]

    [Authorize(Policy = "RequireLoggedIn")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ClaimsPrincipal claimsUser = HttpContext.User;
            string nomUsuario = "";
            string fotoPerfil = "";

            if (claimsUser.Identity.IsAuthenticated)
            {
                nomUsuario = claimsUser.Claims.Where(c => c.Type == ClaimTypes.Name)
                    .Select(c => c.Value).SingleOrDefault();

                fotoPerfil = claimsUser.Claims.Where(c => c.Type == "FotoPerfil")
                    .Select(c => c.Value).SingleOrDefault();

            }

            ViewData["nomUsuario"] = nomUsuario;
            ViewData["fotoPerfil"] = fotoPerfil;

           

            return View();
        }

        [Authorize(Roles = "Admin")]

        public IActionResult CitasMedicas()
        {
            return View();
        }

        public IActionResult Doctores()
        {
            return View();
        }

        public IActionResult Especialidad()

        {
            return View();
        }

        public IActionResult HistorialMedico()

        {
            return View();
        }

        public IActionResult Medicamento()

        {
            return View();
        }

        public IActionResult Pacientes()

        {
            return View();
        }
        public IActionResult Roles()

        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

       











    }
}