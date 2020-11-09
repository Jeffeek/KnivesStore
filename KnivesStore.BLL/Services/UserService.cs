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
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private bool _isDisposed;

        public UserService(IUnitOfWork uow, IMapper mapper)
        {
            _unitOfWork = uow;
            _mapper = mapper;
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

        public IEnumerable<UserDTO> GetAll()
        {
            var users = _unitOfWork.UserRepository.GetAll();
            return _mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(users);
        }

        public UserDTO Get(int? id)
        {
            if (id == null || id.Value <= 0) throw new ValidationException("Не установлен id пользователя", nameof(id));
            var user = GetAll().FirstOrDefault(x => x.Id == id.Value);
            if (user == null) throw new ValidationException("Пользователь не найден", nameof(user));
            return user;
        }

        public void Add(UserDTO user)
        {
            if (user == null) throw new ValidationException("NULL: ", nameof(user));
            if (GetAll().Contains(user)) throw new ValidationException("Already exists: ", nameof(user));
            var createdUser = _mapper.Map<UserDTO, User>(user);
            _unitOfWork.UserRepository.Insert(createdUser);
            _unitOfWork.Save();
        }

        public void Update(UserDTO user)
        {
            if (user == null) throw new ValidationException("NULL: ", nameof(user));
            if (!GetAll().Contains(user)) throw new ValidationException("Not exists: ", nameof(user));
            var createdUser = _mapper.Map<UserDTO, User>(user);
            _unitOfWork.UserRepository.Update(createdUser);
            _unitOfWork.Save();
        }

        public void Delete(int? id)
        {
            if (id == null || id.Value <= 0) throw new ValidationException("id <= 0 or NULL: ", nameof(id));
            var user = GetAll().SingleOrDefault(x => x.Id == id.Value);
            if (user == null) throw new ValidationException("Not exists: ", nameof(id));
            var mappedUser = _mapper.Map<UserDTO, User>(user);
            _unitOfWork.UserRepository.Delete(mappedUser);
            _unitOfWork.Save();
        }
    }
}
