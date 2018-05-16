﻿using System.ComponentModel.DataAnnotations;

namespace SimplesJustica.Identity.Models
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}