using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWashing.Shared.Entities
{
    public class History
    {
        public int HistoryId { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }

        // Clave foránea para del Vehículo.
        public int VehículoId { get; set; }
        public Vehicle Servicio { get; set; }
    }
}
