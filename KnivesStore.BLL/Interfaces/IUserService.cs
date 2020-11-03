using System;
using System.Collections.Generic;
using System.Text;
using KnivesStore.BLL.DTO;

namespace KnivesStore.BLL.Interfaces
{
    public interface IUserService : IDisposable
    {
        IEnumerable<UserDTO> GetAll();
        UserDTO Get(int? id);
        void Add(UserDTO user);
        void Update(UserDTO user);
        void Delete(int? id);
    }
}
