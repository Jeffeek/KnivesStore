using System;
using System.Collections.Generic;
using System.Linq;
using KnivesStore.BLL.DTO;
using KnivesStore.BLL.Interfaces;
using KnivesStore.BLL.Models;

namespace KnivesStore.BLL.Services
{
    public class BasketService : IBasketService
    {
        public event EventHandler BasketChanged;
        private int _sum = 0;
        private IKnifeService _knifeService;
        public Dictionary<KnifeDTO, int> KnivesList { get; }

        public int Sum
        {
            get => _sum;
            private set
            {
                _sum = value;
                BasketChanged?.Invoke(this, new EventArgs());
            }
        }

        public BasketService(IKnifeService knifeService)
        {
            _knifeService = knifeService;
            KnivesList = new Dictionary<KnifeDTO, int>();
        }

        public void Add(int knifeId)
        {
            var knife = _knifeService.Get(knifeId);
            if (KnivesList.ContainsKey(knife))
            {
                KnivesList[knife]++;
            }
            else
            {
                KnivesList.Add(knife, 1);
            }

            Sum += knife.Price;
        }

        public void Remove(int knifeId)
        {
            var knife = _knifeService.Get(knifeId);
            if (KnivesList.ContainsKey(knife))
            {
                if (KnivesList[knife] == 1)
                    KnivesList.Remove(knife);
                else
                    KnivesList[knife]--;
                Sum -= knife.Price;
            }
        }

        public void Clear()
        {
            KnivesList.Clear();
            Sum = 0;
        }

        public void UseDiscount(IDiscount discount)
        {
            int sum = KnivesList.Keys.Sum(x => x.Price);
            Sum = (int)Math.Ceiling(discount.GetTotalPriceWithDiscount(sum));
        }
    }
}
