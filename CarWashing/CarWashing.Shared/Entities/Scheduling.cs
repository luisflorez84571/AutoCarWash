using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWashing.Shared.Entities
{
    public class Scheduling
    {
        public int SchedulingId { get; set; }

        [Display(Name = "Fecha")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateTime date { get; set; }

        [Display(Name = "Hora")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public TimeSpan Hour { get; set; }

        public int ClientId { get; set; }
        public int VehicleId { get; set; }
        public string ClientName { get; set; } = string.Empty;
    }
}
