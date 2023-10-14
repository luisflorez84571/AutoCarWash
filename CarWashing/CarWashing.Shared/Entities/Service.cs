using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWashing.Shared.Entities
{
    public class Service
    {
        public int ServiceId { get; set; }
        public string Servicio { get; set; }
        public decimal Precio { get; set; }
        public string Vehiculo { get; set; }

        public int VehicleId { get; set; }
    }
}
