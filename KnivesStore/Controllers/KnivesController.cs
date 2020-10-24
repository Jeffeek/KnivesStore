using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using KnivesStore.BLL.DTO;
using KnivesStore.BLL.Interfaces;
using KnivesStore.PL.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace KnivesStore.PL.Controllers
{
    public class KnivesController : Controller
    {
        private readonly IKnifeService _knifeService;
        private readonly IMapper _mapper;

        public KnivesController(IKnifeService productService, IMapper mapper)
        {
            _knifeService = productService;
            _mapper = mapper;
        }

        public IActionResult Items()
        {
            var supplies = _mapper.Map<IEnumerable<KnifeDTO>, IEnumerable<KnifeViewModel>>(_knifeService.GetAll());
            return View(supplies);
        }

        public IActionResult Delete(int? id)
        {
            _knifeService.Delete(id);
            return RedirectToAction("Items");
        }

        public IActionResult Details(int? id)
        {
            var item = _mapper.Map<KnifeDTO, KnifeViewModel>(_knifeService.Get(id));
            return View(item);
        }

        [HttpGet]
        public IActionResult Create()
        {
            int newId = _knifeService.GetAll().Max(x => x.Id) + 1;
            var knife = new KnifeViewModel() {Id = newId};
            return View(knife);
        }

        [HttpPost]
        public IActionResult Create(KnifeViewModel knife)
        {
            var mappedKnife = _mapper.Map<KnifeViewModel, KnifeDTO>(knife);
            _knifeService.Add(mappedKnife);
            return RedirectToAction("Items");
        }
    }
}
