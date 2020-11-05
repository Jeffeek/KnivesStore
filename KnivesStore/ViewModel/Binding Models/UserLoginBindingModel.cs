using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KnivesStore.PL.ViewModel.Binding_Models
{
    public class UserLoginBindingModel
    {
        [StringLength(45, MinimumLength = 6, ErrorMessage = "Minimum length is 6 and max 45 characters.")]
        [Required]
        [Display(Name = "Login")]
        [DataType(DataType.Text)]
        public string Login { get; set; }

        [StringLength(100, ErrorMessage = "Maximum length is 100 characters, min 10.", MinimumLength = 10)]
        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
