using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace ProgramareSpital.Models.ViewModels
{
    public class RegisterViewModel
    {  
        [Required]
        [Display(Name = "Nume Complet")]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Adresa de Email")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage ="Parola trebuie sa aiba minim 6 caractere!", MinimumLength = 6)]
        [Display(Name = "Parola")]
        public string Password { get; set; }

        [Display(Name = "Confirma parola")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Parola si Confirma parola nu se potrivesc!")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Rol")]
        public string RoleName { get; set; }

    }
}
