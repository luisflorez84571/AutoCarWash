﻿using System.ComponentModel.DataAnnotations;

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

        public User User { get; set; }
        public int UserId { get; set; }

    }
}
