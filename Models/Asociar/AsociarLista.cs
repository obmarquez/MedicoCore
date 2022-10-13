using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicoCore.Models.Asociar
{
    public class AsociarLista
    {
        public int idhistorico { get; set; }
        public int ide { get; set; }
        public string curp { get; set; }
        public string evaluado { get; set; }
        public string cevaluacion { get; set; }
        public string idMedico { get; set; }
        public string fecha { get; set; }
        public string sexo { get; set; }
        public string precarga { get; set; }
        public string fProbableEval { get; set; }
        public string gaf { get; set; }
        public string grupo { get; set; }
        public string HayVinculo { get; set; }
    }
}
