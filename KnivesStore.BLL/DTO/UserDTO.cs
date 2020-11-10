using System.Collections.Generic;
using KnivesStore.DAL.Models;

namespace KnivesStore.BLL.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
        public ICollection<CheckDTO> Checks;
    }
}
