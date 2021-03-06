﻿using System;
using System.Collections.Generic;

namespace KnivesStore.BLL.DTO
{
    public class ProducerDTO
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string Name { get; set; }
        public ICollection<KnifeDTO> Knives;
    }
}
