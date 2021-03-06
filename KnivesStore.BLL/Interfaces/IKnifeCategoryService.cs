﻿using System.Collections.Generic;
using KnivesStore.BLL.DTO;

namespace KnivesStore.BLL.Interfaces
{
    public interface IKnifeCategoryService
    {
        void Add(KnifeCategoryDTO category);
        KnifeCategoryDTO Get(int? id);
        void Delete(int? id);
        void Update(KnifeCategoryDTO category);
        IEnumerable<KnifeCategoryDTO> GetAll();
    }
}
