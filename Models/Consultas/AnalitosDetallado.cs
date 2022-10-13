using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicoCore.Models.Consultas
{
    public class AnalitosDetallado
    {
        public string Evaluado { get; set; }
        public string Sexo { get; set; }
        public string Edad { get; set; }
        public string Dependencia { get; set; }
        public string Fecha { get; set; }
        public string Folio { get; set; }
        public bool RS_MARI { get; set; }
        public bool RS_COCA { get; set; }
        public bool RS_BENZO { get; set; }
        public bool RS_BARBI { get; set; }
        public bool RS_ANFE { get; set; }
        public bool RS_META { get; set; }
    }
}
