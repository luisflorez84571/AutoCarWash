using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWashing.Shared.Entities
{
    public class Bill
    {
        public int BillId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal MontoTotal { get; set; }


        // Clave foránea para el Cliente al que se emite la factura
        public int ClientId { get; set; }
        public int VehicleId { get; set; }
        public string ClientName { get; set; } = string.Empty;



    }
}