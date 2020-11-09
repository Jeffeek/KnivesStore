using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using KnivesStore.BLL.DTO;
using KnivesStore.BLL.Infrastructure;
using KnivesStore.BLL.Interfaces;
using KnivesStore.DAL.DataAccessors.DB.UnitOfWork;
using KnivesStore.DAL.Models;

namespace KnivesStore.BLL.Services
{
    public class CheckService : ICheckService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private bool _isDisposed;

        public CheckService(IUnitOfWork uow, IMapper mapper)
        {
            _unitOfWork = uow;
            _mapper = mapper;
        }

        public CheckDTO Get(int? id)
        {
            if (id == null || id.Value <= 0) throw new ValidationException("Не установлено id ножа", "");
            var sale = GetAll().FirstOrDefault(x => x.Id == id.Value);
            if (sale == null) throw new ValidationException("Нож не найден", "");
            return sale;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    _unitOfWork.Dispose();
                }
                _isDisposed = true;
            }
        }

        public IEnumerable<CheckDTO> GetAll()
        {
            var sales = _unitOfWork.CheckRepository.GetAll();
            return _mapper.Map<IEnumerable<Check>, IEnumerable<CheckDTO>>(sales);
        }

        public void Add(CheckDTO order)
        {
            if (order == null) throw new ValidationException("NULL: ", nameof(order));
            if (GetAll().Contains(order)) throw new ValidationException("Already exists: ", nameof(order));
            var createdSale = _mapper.Map<CheckDTO, Check>(order);
            _unitOfWork.CheckRepository.Insert(createdSale);
            _unitOfWork.Save();
        }

        public void Update(CheckDTO sale)
        {
            if (sale == null) throw new ValidationException("NULL: ", nameof(sale));
            if (!GetAll().Contains(sale)) throw new ValidationException("NOT exists: ", nameof(sale));
            var createdSale = _mapper.Map<CheckDTO, Check>(sale);
            _unitOfWork.CheckRepository.Update(createdSale);
            _unitOfWork.Save();
        }

        public void Delete(int? id)
        {
            if (id <= 0) throw new ValidationException("id <= 0: ", nameof(id));
            var sale = GetAll().SingleOrDefault(x => x.Id == id);
            if (sale == null) throw new ValidationException("Not exists: ", nameof(id));
            var mappedSale = _mapper.Map<CheckDTO, Check>(sale);
            _unitOfWork.CheckRepository.Delete(mappedSale);
            _unitOfWork.Save();
        }
    }
}
