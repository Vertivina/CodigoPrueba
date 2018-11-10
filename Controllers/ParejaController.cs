using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using vertivina.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models.MvcContext;
using System.Threading;

namespace vertivina.Controllers
{
    public class ParejaController : Controller
    {

        private readonly MvcContext _context;

        public ParejaController(MvcContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        /* no me dejaba guardar */
        public async Task<IActionResult> ListaCita(string searchString)
        {
            var citas = from m in _context.Cita
                        select m;
            if (!String.IsNullOrEmpty(searchString))
            {
                citas = citas.Where(s => s.Nombre.Contains(searchString));
            }

            return View(await citas.ToListAsync());
        }


        public IActionResult Faq()
        {
            ViewData["Message"] = "Tienes dudas?";

            return View();
        }
        public IActionResult Vistapareja()
        {
            ViewData["Message"] = "Tienes dudas?";

            return View();
        }
        public IActionResult Pareja()
        {
            ViewData["Message"] = "Tienes dudas?";

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Pareja([Bind("NombreDueño,Mascota,NombreMascota,Parejas,Telefono,TipoTelefono,email,Fecha,Direccion,Motivo1,Motivo2,Solicito")] Pareja pareja)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pareja);
                await _context.SaveChangesAsync();

                return RedirectToAction("ConfirmarPareja", "Pareja");
            }
            return View(pareja);
        }
        public IActionResult ConfirmarPareja()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Faq([Bind("contactoNombre,tlf,email,msj,nombrePersonal,respuesta,motivos,solicito,fechaInc")] Faq faq)
        {
            if (ModelState.IsValid)
            {
                _context.Add(faq);
                await _context.SaveChangesAsync();

                return RedirectToAction("ConfirmarFaq", "Home");
            }
            return View(faq);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registrar([Bind("names,email,user,pass,pass2")] Registrar registrar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registrar);
                await _context.SaveChangesAsync();

                return RedirectToAction("ConfirmarRegistrar", "Home");
            }
            return View(registrar); /*  sss */
        }
        public IActionResult ConfirmarRegistrar()
        {
            return View();
        }


        /*Para la conexion con la base de datos
         public  async Task<IActionResult> Adopcion(String buscar)
        {
             var adopciones = from m in _context.Mascota
                 select m;
             if (!String.IsNullOrEmpty(buscar))
            {
               adopciones  = adopciones .Where(s => s.nombre.Contains(buscar));
            }

            return View(await adopciones.ToListAsync());
        }*/
        public IActionResult Adopta()
        {
            return View();
        }
        public IActionResult Adopcion()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Adopcion([Bind("NombreDueño,Mascota,NombreMascota,Telefono,TipoTelefono,email,Fecha,Direccion,Motivo1,Motivo2,Solicito")] Adopcion adopcion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adopcion);
                await _context.SaveChangesAsync();
                return RedirectToAction("ConfirmarAdopcion");
            }
            return View(adopcion);
        }
        public IActionResult ConfirmarAdopcion()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



    }
}
