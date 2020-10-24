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
    public class KnifeCategoryService : IKnifeCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private bool _isDisposed;

        public KnifeCategoryService(IUnitOfWork uow, IMapper mapper)
        {
            _unitOfWork = uow;
            _mapper = mapper;
        }

        public void Add(KnifeCategoryDTO category)
        {
            if (category == null) throw new ValidationException("NULL: ", nameof(category));
            if (GetAll().Contains(category)) throw new ValidationException("Already exists: ", nameof(category));
            var mappedCategory = _mapper.Map<KnifeCategoryDTO, KnifeCategory>(category);
            _unitOfWork.KnifeCategoryRepository.Insert(mappedCategory);
            _unitOfWork.Save();
        }

        public KnifeCategoryDTO Get(int? id)
        {
            if (id == null || id.Value <= 0) throw new ValidationException("Не установлено id категории", "");
            var category = GetAll().FirstOrDefault(x => x.Id == id.Value);
            if (category == null) throw new ValidationException("Категория не найдена", "");
            return category;
        }

        public void Delete(int? id)
        {
            if (id == null || id.Value <= 0) throw new ValidationException("id <= 0 or NULL: ", nameof(id));
            var category = GetAll().SingleOrDefault(x => x.Id == id.Value);
            var mappedCategory = _mapper.Map<KnifeCategoryDTO, KnifeCategory>(category);
            if (category == null) throw new ValidationException("Not exists: ", nameof(id));
            _unitOfWork.KnifeCategoryRepository.Delete(mappedCategory);
            _unitOfWork.Save();
        }

        public void Update(KnifeCategoryDTO category)
        {
            if (category == null) throw new ValidationException("NULL: ", nameof(category));
            if (GetAll().Contains(category)) throw new ValidationException("NOT exists: ", nameof(category));
            var mappedCategory = _mapper.Map<KnifeCategoryDTO, KnifeCategory>(category);
            _unitOfWork.KnifeCategoryRepository.Update(mappedCategory);
            _unitOfWork.Save();
        }

        public IEnumerable<KnifeCategoryDTO> GetAll()
        {
            var categories = _unitOfWork.KnifeCategoryRepository.GetAll();
            return _mapper.Map<IEnumerable<KnifeCategory>, IEnumerable<KnifeCategoryDTO>>(categories);
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
    }
}
