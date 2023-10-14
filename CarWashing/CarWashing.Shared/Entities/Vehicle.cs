using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWashing.Shared.Entities
{
    public class Vehicle
    {
        public int VehicleId { get; set; }
        public string Marca { get; set; }
        public string Color { get; set; }
        public string NúmeroPlaca { get; set; }

        // Clave foránea para el Cliente al que pertenece el vehículo
        public int ClientId { get; set; }
        public Client Client { get; set; }        

    }
}
