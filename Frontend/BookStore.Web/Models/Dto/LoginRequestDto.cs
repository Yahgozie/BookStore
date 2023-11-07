﻿using System.ComponentModel.DataAnnotations;

namespace BookStore.Web.Models.Dto
{
    public class LoginRequestDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
