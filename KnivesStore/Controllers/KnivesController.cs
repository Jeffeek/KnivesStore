using System.Collections.Generic;
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
        private readonly ISaleService _saleService;
        private readonly IMapper _mapper;

        public KnivesController(ISaleService supplyService, IKnifeService productService, IMapper mapper)
        {
            _knifeService = productService;
            _saleService = supplyService;
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
    }
}
