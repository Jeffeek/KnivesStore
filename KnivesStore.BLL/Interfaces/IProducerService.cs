using System.Collections.Generic;
using KnivesStore.BLL.DTO;

namespace KnivesStore.BLL.Interfaces
{
    public interface IProducerService
    {
        void Add(ProducerDTO producer);
        ProducerDTO Get(int? id);
        void Delete(int? id);
        IEnumerable<ProducerDTO> GetAll();
    }
}
