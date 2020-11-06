using System;

namespace KnivesStore.BLL.DTO
{
    [Serializable]
    public class ProducerDTO
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string Name { get; set; }
    }
}
