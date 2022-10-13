using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicoCore.Models.Impresiones
{
    public class ListadoDiario
    {
        public string codigo { get; set; }
        public string curp { get; set; }
        public string evaluado { get; set; }
        public string folio { get; set; }
        public string gaf { get; set; }
        public string grupo { get; set; }
        public string cevaluacion { get; set; }
        public string desc_dependencia { get; set; }
    }
}
