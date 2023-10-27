using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Display(Name = "Fecha")]
        [MaxLength(20, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateTime Fecha { get; set; }

        [Display(Name = "Total")]
        [MaxLength(20, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
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