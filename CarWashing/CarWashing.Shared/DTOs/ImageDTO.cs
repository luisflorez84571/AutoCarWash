﻿using System.ComponentModel.DataAnnotations;

namespace CarWashing.Shared.DTOs
{
    public class ImageDTO
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        public List<string> Images { get; set; } = null!;
    }

}
