using System;
using System.Collections.Generic;

namespace KnivesStore.BLL.DTO
{
    public class CheckDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public UserDTO User { get; set; }
        public DateTime Date { get; set; }
        public int Sum { get; set; }
        public ICollection<SellDTO> Sells { get; set; }
    }
}
