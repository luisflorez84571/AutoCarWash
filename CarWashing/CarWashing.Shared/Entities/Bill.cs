using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
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
        [JsonIgnore]
        public Client Client { get; set; }       
        

        public String ServiceId { get; set; }
        [JsonIgnore]
        public Service Service { get; set; }

        public string ClientName { get; set; } = string.Empty;

        [JsonIgnore]
        public ICollection<Bill> Bills { get; set; }
        

    }
}