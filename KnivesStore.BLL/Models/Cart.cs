using System;
using System.Collections.Generic;
using System.Linq;
using KnivesStore.BLL.DTO;

namespace KnivesStore.BLL.Models
{
    public class Cart
    {
        private Dictionary<KnifeDTO, int> _productsDictionary;
        public int RealSum { get; private set; }
        public int DiscountSum { get; private set; }

        public Cart()
        {
            _productsDictionary = new Dictionary<KnifeDTO, int>();
            DiscountSum = RealSum;
        }

        private void CalculateSum()
        {
            RealSum = _productsDictionary.Sum(x => x.Key.Price * x.Value);
        }

        public void Add(KnifeDTO knife)
        {
            if (_productsDictionary.ContainsKey(knife))
            {
                _productsDictionary[knife]++;
            }
            else
            {
                _productsDictionary.Add(knife, 1);
            }
            CalculateSum();
        }

        public void Remove(KnifeDTO knife)
        {
            if (_productsDictionary.ContainsKey(knife))
            {
                if (_productsDictionary[knife] == 1)
                    _productsDictionary.Remove(knife);
                else
                    _productsDictionary[knife]++;
                CalculateSum();
            }
            else
            {
                throw new ArgumentException("Такого ножа нет в корзине!");
            }
        }

        public void Clear()
        {
            _productsDictionary.Clear();
            CalculateSum();
        }

        public void UseDiscount(IDiscount discount)
        {
            int sum = RealSum;
            DiscountSum = (int)Math.Ceiling(discount.GetTotalPriceWithDiscount(sum));
        }

        public List<KeyValuePair<KnifeDTO, int>> GetAll()
        {
            var list = new List<KeyValuePair<KnifeDTO, int>>();
            for (int i = 0; i < _productsDictionary.Count; i++)
                list.Add(_productsDictionary.ElementAt(i));
            return list;
        }
    }
}
