using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;

namespace KnivesStore.PL.ViewModel.Binding_Models
{
    public class UserRegistrationBindingModel
    {
        [StringLength(45, MinimumLength = 6, ErrorMessage = "Minimum length is 6 and max 45 characters.")]
        [Required]
        [Display(Name = "Login")]
        [DataType(DataType.Text)]
        public string Login { get; set; }

        [StringLength(50, ErrorMessage = "Maximum length is 50 characters.")]
        [Required]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email does not match the pattern.")]
        [Compare("ConfirmEmail", ErrorMessage = "Email and Confirm Email fields should be the same.")]
        public string Email { get; set; }

        [StringLength(50, ErrorMessage = "Maximum length is 50 characters.")]
        [Required]
        [Display(Name = "Confirm Email Address")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email does not match the pattern.")]
        [Compare("Email", ErrorMessage = "Email and Confirm Email fields should be the same.")]
        public string ConfirmEmail { get; set; }

        [StringLength(100, ErrorMessage = "Maximum length is 100 characters, min 10.", MinimumLength = 10)]
        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Compare("ConfirmPassword", ErrorMessage = "Password and Confirm Password fields should be the same.")]
        public string Password { get; set; }

        [StringLength(100, ErrorMessage = "Maximum length is 100 characters, mim 10.", MinimumLength = 10)]
        [Required]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and Confirm Password fields should be the same.")]
        public string ConfirmPassword { get; set; }
    }
}
