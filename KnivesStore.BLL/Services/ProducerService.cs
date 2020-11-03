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
    public class ProducerService : IProducerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private bool _isDisposed;

        public ProducerService(IUnitOfWork uow, IMapper mapper)
        {
            _unitOfWork = uow;
            _mapper = mapper;
        }

        public void Add(ProducerDTO producer)
        {
            if (producer == null) throw new ValidationException("NULL: ", nameof(producer));
            if (GetAll().Contains(producer)) throw new ValidationException("Already exists: ", nameof(producer));
            var mappedCategory = _mapper.Map<ProducerDTO, Producer>(producer);
            _unitOfWork.ProducerRepository.Insert(mappedCategory);
            _unitOfWork.Save();
        }

        public ProducerDTO Get(int? id)
        {
            if (id == null || id.Value <= 0) throw new ValidationException("Не установлено id изготовителя", "");
            var producer = GetAll().FirstOrDefault(x => x.Id == id.Value);
            if (producer == null) throw new ValidationException("Изготовитель не найден", "");
            return producer;
        }

        public void Delete(int? id)
        {
            if (id == null || id.Value <= 0) throw new ValidationException("id <= 0 or NULL: ", nameof(id));
            var producer = GetAll().SingleOrDefault(x => x.Id == id.Value);
            var mappedProducer = _mapper.Map<ProducerDTO, Producer>(producer);
            if (mappedProducer == null) throw new ValidationException("Not exists: ", nameof(id));
            _unitOfWork.ProducerRepository.Delete(mappedProducer);
            _unitOfWork.Save();
        }

        public void Update(ProducerDTO category)
        {
            if (category == null) throw new ValidationException("NULL: ", nameof(category));
            if (!GetAll().Contains(category)) throw new ValidationException("Not exists: ", nameof(category));
            var mappedCategory = _mapper.Map<ProducerDTO, Producer>(category);
            _unitOfWork.ProducerRepository.Update(mappedCategory);
            _unitOfWork.Save();
        }

        public IEnumerable<ProducerDTO> GetAll()
        {
            var producers = _unitOfWork.ProducerRepository.GetAll();
            return _mapper.Map<IEnumerable<Producer>, IEnumerable<ProducerDTO>>(producers);
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
