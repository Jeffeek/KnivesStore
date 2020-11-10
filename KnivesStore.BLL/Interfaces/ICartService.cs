using System;
using System.Collections.Generic;
using KnivesStore.BLL.DTO;
using KnivesStore.BLL.Models;

namespace KnivesStore.BLL.Interfaces
{
    public interface ICartService
    {
        event EventHandler BasketChanged;
        void Add(int knifeId, int userId);
        void Remove(int knifeId); 
        List<KeyValuePair<KnifeDTO, int>> GetAll();
        int CartId { get; }
        void Clear();
        void UseDiscount(IDiscount discount);
        int Sum { get; }
    }
}
