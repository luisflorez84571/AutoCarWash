using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CarWashing.Shared.Entities
{
    public class Service
    {
        public int ServiceId { get; set; }

        [Display(Name = "Servicio")]
        [MaxLength(20, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Servicio { get; set; }

        [Display(Name = "Precio")]
        [MaxLength(20, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public decimal Precio { get; set; }

        [Display(Name = "Vehiculo")]
        [MaxLength(20, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Vehiculo { get; set; }

        public int ClientId { get; set; }
        [JsonIgnore]
        public Client Client { get; set; }

        [JsonIgnore]
        public ICollection<Service> Services { get; set; }
    }
}
