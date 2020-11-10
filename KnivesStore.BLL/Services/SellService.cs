using System;
using System.Collections.Generic;
using AutoMapper;
using KnivesStore.BLL.DTO;
using KnivesStore.BLL.Interfaces;
using KnivesStore.DAL.DataAccessors.DB.UnitOfWork;
using KnivesStore.DAL.Models;

namespace KnivesStore.BLL.Services
{
    public class SellService : ISellService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private bool _isDisposed;

        public SellService(IMapper mapper, IUnitOfWork iuw)
        {
            _mapper = mapper;
            _unitOfWork = iuw;
        }

        public IEnumerable<SellDTO> GetAll()
        {
            var items = _unitOfWork.SellRepository.GetAll();
            return _mapper.Map<IEnumerable<Sell>, IEnumerable<SellDTO>>(items);
        }

        public SellDTO Get(int? id)
        {
            var item = _unitOfWork.SellRepository.Get(x => x.Id == id);
            return _mapper.Map<Sell, SellDTO>(item);
        }

        public void Add(SellDTO sell)
        {
            var item = _mapper.Map<SellDTO, Sell>(sell);
            _unitOfWork.SellRepository.Insert(item);
        }

        public void Update(SellDTO sell)
        {
            var item = _mapper.Map<SellDTO, Sell>(sell);
            _unitOfWork.SellRepository.Update(item);
        }

        public void Delete(int? id)
        {
            var item = _unitOfWork.SellRepository.Get(x => x.Id == id);
            _unitOfWork.SellRepository.Delete(item);
        }
    }
}
