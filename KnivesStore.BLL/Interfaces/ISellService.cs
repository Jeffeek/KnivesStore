using System.Collections.Generic;
using KnivesStore.BLL.DTO;

namespace KnivesStore.BLL.Interfaces
{
    interface ISellService
    {
        IEnumerable<SellDTO> GetAll();
        SellDTO Get(int? id);
        void Add(SellDTO sale);
        void Update(SellDTO sale);
        void Delete(int? id);
    }
}
