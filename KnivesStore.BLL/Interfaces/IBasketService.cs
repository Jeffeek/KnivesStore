using System;
using System.Collections.Generic;
using KnivesStore.BLL.DTO;
using KnivesStore.BLL.Models;
using KnivesStore.BLL.Services;

namespace KnivesStore.BLL.Interfaces
{
    public interface IBasketService
    {
        event EventHandler BasketChanged;
        Dictionary<KnifeDTO, int> KnivesList { get; }
        void Add(int knifeId);
        void Remove(int knifeId);
        void Clear();
        void UseDiscount(IDiscount discount);
        int Sum { get; }
    }
}
