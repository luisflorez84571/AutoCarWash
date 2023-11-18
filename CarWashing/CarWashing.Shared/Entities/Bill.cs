using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

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


        // Clave foránea para el Usuario al que se emite la factura

        public String ServiceId { get; set; }
        [JsonIgnore]
        public Service Service { get; set; }

        [JsonIgnore]
        public ICollection<Bill> Bills { get; set; }

        public User User { get; set; }

        public string UserId { get; set; }
    }
}