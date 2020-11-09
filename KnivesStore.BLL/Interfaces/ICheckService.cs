using System;
using System.Collections.Generic;
using KnivesStore.BLL.DTO;

namespace KnivesStore.BLL.Interfaces
{
    public interface ICheckService : IDisposable
    {
        IEnumerable<CheckDTO> GetAll();
        CheckDTO Get(int? id);
        void Add(CheckDTO sale);
        void Update(CheckDTO sale);
        void Delete(int? id);
    }
}
