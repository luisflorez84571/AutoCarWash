using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

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

        public User User { get; set; }
        public int UserId { get; set; }

        public int VehicleId { get; set; }
        [JsonIgnore]
        public Vehicle Vehicle { get; set; }

        public int ServiceId { get; set; }
        [JsonIgnore]
        public Service Service { get; set; }

        [JsonIgnore]
        public ICollection<Scheduling> Schedulings { get; set; }
    }
}
