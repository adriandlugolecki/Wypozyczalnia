﻿using System.ComponentModel.DataAnnotations;

namespace webAPI.Models
{
    public class Ubezpieczenie
    {
        [Key] 
        public int Id { get; set; }
        public string Nazwa { get; set; } = string.Empty;
        public string procent { get; set; } = string.Empty;

    }
}
