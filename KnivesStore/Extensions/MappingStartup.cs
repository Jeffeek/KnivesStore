using AutoMapper;
using KnivesStore.BLL.DTO;
using KnivesStore.DAL.Models;
using KnivesStore.PL.ViewModel;
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

            CreateMap<SaleDTO, Sale>();
            CreateMap<Sale, SaleDTO>();

            CreateMap<UserDTO, User>();
            CreateMap<User, UserDTO>();
            CreateMap<UserRegistrationBindingModel, UserDTO>();
            CreateMap<UserLoginBindingModel, UserDTO>();
        }
    }
}
