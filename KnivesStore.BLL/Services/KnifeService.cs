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
    public class KnifeService : IKnifeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private bool _isDisposed;

        public KnifeService(IUnitOfWork uow, IMapper mapper)
        {
            _unitOfWork = uow;
            _mapper = mapper;
        }

        public KnifeDTO Get(int? id)
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

        public IEnumerable<KnifeDTO> GetAll()
        {
            var knives = _unitOfWork.KnifeRepository.GetAll();
            return _mapper.Map<IEnumerable<Knife>, IEnumerable<KnifeDTO>>(knives);
        }

        public void Add(KnifeDTO knifeDTO)
        {
            if (knifeDTO == null) throw new ValidationException("NULL: ", nameof(knifeDTO));
            if (GetAll().Contains(knifeDTO)) throw new ValidationException("Already exists: ", nameof(knifeDTO));
            var createdSale = _mapper.Map<KnifeDTO, Knife>(knifeDTO);
            _unitOfWork.KnifeRepository.Insert(createdSale);
            _unitOfWork.Save();
        }

        public void Delete(int? id)
        {
            if (id == null || id.Value <= 0) throw new ValidationException("id <= 0 or NULL: ", nameof(id));
            var sale = GetAll().SingleOrDefault(x => x.Id == id.Value);
            var mappedSale = _mapper.Map<KnifeDTO, Knife>(sale);
            if (sale == null) throw new ValidationException("Not exists: ", nameof(id));
            _unitOfWork.KnifeRepository.Delete(mappedSale);
            _unitOfWork.Save();
        }
    }
}
