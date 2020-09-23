using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Unidad2Actividad3.Models;

namespace Unidad2Actividad3.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            villancicosContext context = new villancicosContext();
            var villancicos = context.Villancico.OrderBy(x=>x.Nombre);
            return View(villancicos);
        }
        public IActionResult Villancico(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            villancicosContext context = new villancicosContext();
            var v = context.Villancico.FirstOrDefault(x => x.Id==id);
            if (v == null)
            {
                return RedirectToAction("Index");
            }
            else
            return View(v);
        }
    }
}
