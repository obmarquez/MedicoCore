using MedicoCore.Data;
using MedicoCore.Models.Consultas;
using MedicoCore.Views.Consultas;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicoCore.Controllers
{

    [Authorize]

    public class ConsultasController : Controller
    {
        private DBOperaciones repo;

        public ConsultasController()
        {
            repo = new DBOperaciones();
        }

        [Authorize(Roles = "Administrador, SupervisorMedico")]
        public IActionResult EntradaDiaria(string fecha = "")
        {
            if(fecha == "")
            {
                return View();
            }
            else
            {
                return View(repo.Getdosparam1<EntradaDiaria>("sp_medico_entrada_diaria_x_fecha_supervision_core", new { @fecha = fecha }).ToList());
            }            
        }

        [Authorize(Roles = "Administrador, SupervisorMedico")]
        public IActionResult EntradaDiariaPAF(string fecha = "")
        {
            if (fecha == "")
            {
                return View();
            }
            else
            {
                return View(repo.Getdosparam1<EntradaDiariaPAF>("sp_medico_entrada_diaria_x_fecha_paf_tox_supervision_core", new { @fecha = fecha }).ToList());
            }
        }

        [Authorize(Roles = "Administrador, SupervisorMedico")]
        public IActionResult Poa(int mes = 0, int anio = 0)
        {
            ViewBag.elMes = mes;

            List<SelectListItem> meses = new List<SelectListItem>();
            meses.Add(new SelectListItem { Text = "Enero", Value = "1" });
            meses.Add(new SelectListItem { Text = "Febrero", Value = "2" });
            meses.Add(new SelectListItem { Text = "Marzo", Value = "3" });
            meses.Add(new SelectListItem { Text = "Abril", Value = "4" });
            meses.Add(new SelectListItem { Text = "Mayo", Value = "5" });
            meses.Add(new SelectListItem { Text = "Junio", Value = "6" });
            meses.Add(new SelectListItem { Text = "Julio", Value = "7" });
            meses.Add(new SelectListItem { Text = "Agosto", Value = "8" });
            meses.Add(new SelectListItem { Text = "Septiembre", Value = "9" });
            meses.Add(new SelectListItem { Text = "Octubre", Value = "10" });
            meses.Add(new SelectListItem { Text = "Noviembre", Value = "11" });
            meses.Add(new SelectListItem { Text = "Diciembre", Value = "12" });
            ViewBag.losMeses = meses;

            if (mes == 0 || anio == 0)
            {
                return View();
            }
            else
            {
                //Total expedientes entregados a Custodia                
                ViewBag.TotalEntregadoCustodia = repo.Getdosparam1<Poa>("sp_medicos_poa_mes_anio", new { @mes = mes, @anio = anio, @opcion = 1 }).FirstOrDefault();
                ViewBag.EntregaCustodiaGenero = repo.Getdosparam1<Poa>("sp_medicos_poa_mes_anio", new { @mes = mes, @anio = anio, @opcion = 2 }).ToList();
                ViewBag.EntregaCustodiaDetalle = repo.Getdosparam1<Poa>("sp_medicos_poa_mes_anio", new { @mes = mes, @anio = anio, @opcion = 3 }).ToList();
                ViewBag.TotalFinalizados = repo.Getdosparam1<Poa>("sp_medicos_poa_mes_anio", new { @mes = mes, @anio = anio, @opcion = 4 }).FirstOrDefault();
                ViewBag.FinalizadosGenero = repo.Getdosparam1<Poa>("sp_medicos_poa_mes_anio", new { @mes = mes, @anio = anio, @opcion = 5 }).ToList();
                ViewBag.FinalizadoDetalle = repo.Getdosparam1<Poa>("sp_medicos_poa_mes_anio", new { @mes = mes, @anio = anio, @opcion = 6 }).ToList();

                return View();
            }
        }

        [Authorize(Roles = "Administrador, SupervisorMedico")]
        public IActionResult EstadisticioCnca(string fecha1 = "", string fecha2 = "", string opcion = "")
        {
            ViewBag.opcion = opcion;

            List<SelectListItem> opciones = new List<SelectListItem>();
            opciones.Add(new SelectListItem { Text = "Concentrado", Value = "Concentrado" });
            opciones.Add(new SelectListItem { Text = "Detallado", Value = "Detallado" });
            ViewBag.lasOpciones = opciones;

            if (fecha1 == "" || fecha2 == "" || opcion == "")
                return View();
            else
            {
                if (opcion == "Concentrado")
                    ViewBag.deVuelta = repo.Getdosparam1<EstadisticiaCnca>("sp_medicos_estadistica_cnca", new { @f1 = fecha1, @f2 = fecha2, @opc = 1 }).ToList();
                else
                    ViewBag.deVuelta = repo.Getdosparam1<EstadisticiaCnca>("sp_medicos_estadistica_cnca", new { @f1 = fecha1, @f2 = fecha2, @opc = 2 }).ToList();

                return View();
            }
        }

        [Authorize(Roles = "Administrador, SupervisorMedico")]
        public IActionResult Electrocardiogramas(string fecha1 = "", string fecha2 = "")
        {
            if(fecha1=="" || fecha2 == "")
            {
                return View();
            }
            else
            {
                return View(repo.Getdosparam1<Electros>("sp_medicos_ecg_lista_rango_fecha", new { @fecha1 = fecha1, @fecha2 = fecha2}).ToList());
            }
        }

        [Authorize(Roles = "Administrador, SupervisorMedico")]
        public IActionResult Diferenciados(string fecha1="", string fecha2 = "")
        {
            if (fecha1 == "" || fecha2 == "")
                return View();
            else
                return View(repo.Getdosparam1<Diferenciados>("sp_medicos_diferencias_lista_rango_fecha", new { @fecha1 = fecha1, @fecha2 = fecha2 }).ToList());
        }

        [Authorize(Roles = "Administrador, SupervisorMedico")]
        public IActionResult Confirmatorios(string fecha1 = "", string fecha2 = "") 
        {
            if (fecha1 == "" || fecha2 == "")
                return View();
            else
            {
                ViewBag.Conteos = repo.Getdosparam1<Confirmatorio>("sp_medicos_confirmatorios_obtener", new { @f1 = fecha1, @f2 = fecha2, @opcion = 1 }).ToList();
                ViewBag.Analitos = repo.Getdosparam1<AnalitosConteo>("sp_medicos_confirmatorios_obtener", new { @f1 = fecha1, @f2 = fecha2, @opcion = 2 }).ToList();
                ViewBag.AnalitosDetallado = repo.Getdosparam1<AnalitosDetallado>("sp_medicos_confirmatorios_obtener", new { @f1 = fecha1, @f2 = fecha2, @opcion = 3 }).ToList();
                return View();
            }
        }

        [Authorize(Roles = "Administrador, SupervisorMedico")]
        public IActionResult EvaluacionesRealizadas(string fecha1 = "", string fecha2 = "")
        {
            if(fecha1 == "" || fecha2 == "")
            {
                return View();
            }
            else
            {
                return View(repo.Getdosparam1<EvaluacionesRealizadas>("sp_medicos_evaluaciones_realizadas_rango_fecha", new { @f1 = fecha1, @f2 = fecha2 }).ToList());
            }
        }
    }
}