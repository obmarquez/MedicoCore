using MedicoCore.Data;
using MedicoCore.Models;
using MedicoCore.Models.Asociar;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicoCore.Controllers
{
    [Authorize]

    public class AsociarController : Controller
    {
        private DBOperaciones repo;

        public AsociarController()
        {
            repo = new DBOperaciones();
        }

        [Authorize(Roles = "Administrador, SupervisorMedico")]
        public IActionResult IndexAsociar()
        {
            ViewBag.losMedicos = repo.Getdosparam1<Usuarios>("sp_medicos_obtener_usuarios", new { @opcion = 4 }).ToList();
            return View(repo.Getdosparam1<AsociarLista>("sp_medicos_asociar_evaluador_por_fecha", new { @fecha = DateTime.Now.ToShortDateString() }).ToList());
        }

        [Authorize(Roles = "Administrador, SupervisorMedico")]
        public IActionResult AsociacionMultiple(string idMedico, string[] input)
        {
            foreach(var x in input)
            {
                repo.Getdosparam1<AsociarLista>("sp_medicos_asociacion_medicos", new { @idhistorico = x, @usermed = idMedico });
            }

            return RedirectToAction("IndexAsociar", "Asociar");
        }
    }

}
