﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
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
        [JsonIgnore]
        public Client Client { get; set; }

        public string VehicleId { get; set; }
        [JsonIgnore]
        public Vehicle Vehicle { get; set; }

        public String ServiceId { get; set; }
        [JsonIgnore]
        public Service Service { get; set; }

        public string ClientName { get; set; } = string.Empty;

        [JsonIgnore]
        public ICollection<Scheduling> Schedulings { get; set; }
    }
}
