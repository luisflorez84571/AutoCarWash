using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CarWashing.Shared.Entities
{
    public class History
    {
        public int HistoryId { get; set; }

        [Display(Name = "Fecha")]
        [MaxLength(20, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateTime Fecha { get; set; }

        [Display(Name = "Descripcion")]
        [MaxLength(20, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Descripcion { get; set; }

        
        // Clave foránea para del Vehículo.

        public int ClientId { get; set; }
        [JsonIgnore]
        public Client Client { get; set; }

        public int VehículoId { get; set; }
        [JsonIgnore]
        public Vehicle Vehicle { get; set; }

        public String ServiceId { get; set; }
        [JsonIgnore]
        public Service Service { get; set; }

        [JsonIgnore]
        public ICollection<History> Histories { get; set; }

    }
}
