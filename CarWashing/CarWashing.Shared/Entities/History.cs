﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

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

        public User User { get; set; }
        public int UserId { get; set; }

        public int VehículoId { get; set; }
        [JsonIgnore]
        public Vehicle Vehicle { get; set; }

        public int ServiceId { get; set; }
        [JsonIgnore]
        public Service Service { get; set; }

        [JsonIgnore]
        public ICollection<History> Histories { get; set; }


    }
}
