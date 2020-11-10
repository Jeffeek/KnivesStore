using System;
using System.Collections.Generic;
using KnivesStore.BLL.DTO;

namespace KnivesStore.BLL.Interfaces
{
    public interface ICheckService : IDisposable
    {
        IEnumerable<CheckDTO> GetAll();
        CheckDTO Get(int? id);
        void Add(CheckDTO check);
        void Update(CheckDTO check);
        void Delete(int? id);
    }
}
