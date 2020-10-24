using System;
using System.Collections.Generic;
using KnivesStore.BLL.DTO;

namespace KnivesStore.BLL.Interfaces
{
    public interface IKnifeService : IDisposable
    {
        void Add(KnifeDTO knife);
        KnifeDTO Get(int? id);
        void Delete(int? id);
        void Update(KnifeDTO knife);
        IEnumerable<KnifeDTO> GetAll();
    }
}
