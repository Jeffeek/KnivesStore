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
            if (id == null || id.Value <= 0) throw new ValidationException("Не установлено id чека", "");
            var check = GetAll().FirstOrDefault(x => x.Id == id.Value);
            if (check == null) throw new ValidationException("Чек не найден", "");
            return check;
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
            var checks = _unitOfWork.CheckRepository.GetAll();
            return _mapper.Map<IEnumerable<Check>, IEnumerable<CheckDTO>>(checks);
        }

        public void Add(CheckDTO check)
        {
            if (check == null) throw new ValidationException("NULL: ", nameof(check));
            if (GetAll().Contains(check)) throw new ValidationException("Already exists: ", nameof(check));
            var createdCheck = _mapper.Map<CheckDTO, Check>(check);
            _unitOfWork.CheckRepository.Insert(createdCheck);
            _unitOfWork.Save();
        }

        public void Update(CheckDTO check)
        {
            if (check == null) throw new ValidationException("NULL: ", nameof(check));
            if (!GetAll().Contains(check)) throw new ValidationException("NOT exists: ", nameof(check));
            var createdCheck = _mapper.Map<CheckDTO, Check>(check);
            _unitOfWork.CheckRepository.Update(createdCheck);
            _unitOfWork.Save();
        }

        public void Delete(int? id)
        {
            if (id <= 0) throw new ValidationException("id <= 0: ", nameof(id));
            var check = GetAll().SingleOrDefault(x => x.Id == id);
            if (check == null) throw new ValidationException("Not exists: ", nameof(id));
            var mappedSale = _mapper.Map<CheckDTO, Check>(check);
            _unitOfWork.CheckRepository.Delete(mappedSale);
            _unitOfWork.Save();
        }
    }
}
