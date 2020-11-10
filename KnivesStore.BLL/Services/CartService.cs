using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using AutoMapper;
using KnivesStore.BLL.DTO;
using KnivesStore.BLL.Interfaces;
using KnivesStore.BLL.Models;
using KnivesStore.DAL.DataAccessors.DB.UnitOfWork;
using KnivesStore.DAL.Models;

namespace KnivesStore.BLL.Services
{
    public class CartService : ICartService
    {
        public event EventHandler BasketChanged;

        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private Cart _cart;

        public int CartId { get; private set; }
        public int Sum => _cart.DiscountSum;

        public CartService(IUnitOfWork iuw, IMapper mapper)
        {
            _unitOfWork = iuw;
            _cart = new Cart();
            GetCartId();
        }

        private void GetCartId()
        {
            var lastCheck = _unitOfWork.CheckRepository.GetAll().Last();
            if (lastCheck == null)
                CartId = 1;
            else
                CartId = lastCheck.Id + 1;
        }

        public void Add(int knifeId, int userId)
        {
            var knife = _unitOfWork.KnifeRepository.Get(x => x.Id == knifeId);
            if (GetAll().Count == 0)
            {
                var check = new Check()
                {
                    Date = DateTime.Now,
                    Id = CartId,
                    Status = CheckStatus.InBasket,
                    Sum = knife.Price,
                    UserId = userId
                };
                var sell = new Sell()
                {
                    Check = check,
                    CheckId = check.Id,
                    KnifeId = knifeId,
                    Quantity = 1,
                    Knife = knife
                };
                _unitOfWork.CheckRepository.Insert(check);
                _unitOfWork.SellRepository.Insert(sell);
                _unitOfWork.Save();
            }
            var mapped = _mapper.Map<Knife, KnifeDTO>(knife);
            _cart.Add(mapped);
            BasketChanged?.Invoke(this, new EventArgs());
        }

        public void Remove(int knifeId)
        {
            var knife = _unitOfWork.KnifeRepository.Get(x => x.Id == knifeId);
            var mapped = _mapper.Map<Knife, KnifeDTO>(knife);
            _cart.Remove(mapped);
            BasketChanged?.Invoke(this, new EventArgs());
        }

        public void Clear()
        {
            _cart.Clear();
            BasketChanged?.Invoke(this, new EventArgs());
        }

        public void UseDiscount(IDiscount discount)
        {
            _cart.UseDiscount(discount);
            BasketChanged?.Invoke(this, new EventArgs());
        }

        public List<KeyValuePair<KnifeDTO, int>> GetAll() => _cart.GetAll();
    }
}
