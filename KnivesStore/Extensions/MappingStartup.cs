using AutoMapper;
using KnivesStore.BLL.DTO;
using KnivesStore.DAL.Models;
using KnivesStore.PL.ViewModel;

namespace KnivesStore.PL.Extensions
{
    public class MappingStartup : Profile
    {
        public MappingStartup()
        {
            CreateMap<KnifeDTO, Knife>();
            CreateMap<Knife, KnifeDTO>();
            CreateMap<KnifeDTO, KnifeViewModel>();
            CreateMap<KnifeViewModel, KnifeDTO>();
            CreateMap<KnifeViewModel, KnifePanelViewModel>();
            CreateMap<ProducerDTO, Producer>();
            CreateMap<Producer, ProducerDTO>();
            CreateMap<ProducerDTO, ProducerViewModel>();
            CreateMap<ProducerViewModel, ProducerDTO>();
            CreateMap<KnifeCategoryDTO, KnifeCategory>();
            CreateMap<KnifeCategory, KnifeCategoryDTO>();
            CreateMap<KnifeCategoryDTO, KnifeCategoryViewModel>();
            CreateMap<KnifeCategoryViewModel, KnifeCategoryDTO>();
            CreateMap<SaleDTO, Sale>();
            CreateMap<Sale, SaleDTO>();
            CreateMap<SaleDTO, SaleViewModel>();
            CreateMap<SaleViewModel, SaleDTO>();
            CreateMap<UserDTO, User>();
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, UserViewModel>();
            CreateMap<UserViewModel, UserDTO>();
        }
    }
}
