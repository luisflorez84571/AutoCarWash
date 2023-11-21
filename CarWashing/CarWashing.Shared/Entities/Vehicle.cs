using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CarWashing.Shared.Entities
{
    public class Vehicle
    {
        public int VehicleId { get; set; }

        [Display(Name = "Marca")]
        [MaxLength(20, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Marca { get; set; }

        [Display(Name = "Color")]
        [MaxLength(20, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Color { get; set; }

        [Display(Name = "NúmeroPlaca")]
        [MaxLength(10, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string NumeroPlaca { get; set; }

        // Clave foránea para el Cliente al que pertenece el vehículo
        public User User { get; set; }
        public int UserId { get; set; }

        [JsonIgnore]
        public ICollection<Vehicle> Vehicles { get; set; }
        public ICollection<User> Users { get; set; }

    }
}
