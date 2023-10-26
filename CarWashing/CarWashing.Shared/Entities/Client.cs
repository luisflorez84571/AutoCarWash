
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CarWashing.Shared.Entities
{
    public class Client
    {
        public int ClientId { get; set; }

        [Display(Name = "Documento")]
        [MaxLength(20, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Document { get; set; } = null!;

        [Display(Name = "Nombres")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string FirstName { get; set; } = null!;

        [Display(Name = "Apellidos")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string LastName { get; set; } = null!;

        [Display(Name = "Celular")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Celphone { get; set; } = null!;

        [Display(Name = "Correo")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Mail { get; set; } = null!;

        // Vehículos asociados al cliente

        [JsonIgnore]
        public ICollection<Vehicle> Vehicles { get; set; }

        [JsonIgnore]
        public ICollection<Bill> Bills { get; set; }
        [JsonIgnore]
        public ICollection<Client> Clients { get; set; }
    }
}
