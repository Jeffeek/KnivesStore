using System;
using System.Collections.Generic;

namespace KnivesStore.BLL.DTO
{
    public class KnifeCategoryDTO
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public ICollection<KnifeDTO> Knives;
    }
}
