using System.Collections.Generic;
using AutoMapper;
using KnivesStore.BLL.DTO;
using KnivesStore.BLL.Interfaces;
using KnivesStore.PL.ViewModel.Areas.DefaultUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KnivesStore.PL.Controllers
{
    public class StoreController : Controller
    {
        private IKnifeService _knifeService;
        private IMapper _mapper;

        public StoreController(IKnifeService knifeService, IMapper mapper)
        {
            _knifeService = knifeService;
            _mapper = mapper;
        }

        [Authorize(Roles = "Default")]
        public IActionResult Products()
        {
            var products = _knifeService.GetAll();
            var mapped = _mapper.Map<IEnumerable<KnifeDTO>, IEnumerable<KnifeDefaultViewModel>>(products);
            return View(mapped);
        }
    }
}
