using System.Collections.Generic;
using KnivesStore.BLL.DTO;

namespace KnivesStore.BLL.Interfaces
{
    public interface IKnifeCategoryService
    {
        void Add(KnifeCategoryDto category);
        KnifeCategoryDto Get(int? id);
        void Delete(int? id);
        IEnumerable<KnifeCategoryDto> GetAll();
    }
}
