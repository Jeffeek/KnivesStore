using System;

namespace KnivesStore.BLL.DTO
{
    public class CheckDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public UserDTO User { get; set; }
        public DateTime Date { get; set; }
    }
}
