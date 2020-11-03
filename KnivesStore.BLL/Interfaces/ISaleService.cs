using System;
using System.Collections.Generic;
using KnivesStore.BLL.DTO;

namespace KnivesStore.BLL.Interfaces
{
    public interface ISaleService : IDisposable
    {
        IEnumerable<SaleDTO> GetAll();
        SaleDTO Get(int? id);
        void Add(SaleDTO sale);
        void Update(SaleDTO sale);
        void Delete(int? id);
    }
}
