﻿using System.ComponentModel.DataAnnotations;

namespace Final_Project_RentApp.ViewModels.Account
{
    public class RegisterVM
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string FullName { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
