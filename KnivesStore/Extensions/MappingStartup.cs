﻿using AutoMapper;
using KnivesStore.BLL.DTO;
using KnivesStore.DAL.Models;
using KnivesStore.PL.ViewModel;
using KnivesStore.PL.ViewModel.Areas.DefaultUser;
using KnivesStore.PL.ViewModel.Binding_Models;

namespace KnivesStore.PL.Extensions
{
    public class MappingStartup : Profile
    {
        public MappingStartup()
        {
            CreateMap<KnifeDTO, Knife>();
            CreateMap<Knife, KnifeDTO>();

            CreateMap<ProducerDTO, Producer>();
            CreateMap<Producer, ProducerDTO>();

            CreateMap<KnifeCategoryDTO, KnifeCategory>();
            CreateMap<KnifeCategory, KnifeCategoryDTO>();
            CreateMap<KnifeDTO, KnifeDefaultViewModel>();

            CreateMap<CheckDTO, Check>();
            CreateMap<Check, CheckDTO>();

            CreateMap<Sell, SellDTO>();
            CreateMap<SellDTO, Sell>();

            CreateMap<UserDTO, User>();
            CreateMap<User, UserDTO>();
            CreateMap<UserRegistrationBindingModel, UserDTO>();
            CreateMap<UserLoginBindingModel, UserDTO>();
        }
    }
}
