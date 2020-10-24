using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KnivesStore.BLL.DTO;
using KnivesStore.BLL.Interfaces;
using KnivesStore.PL.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KnivesStore.PL.Controllers
{
    public class SalesController : Controller
    {
        private readonly ISaleService _saleService;
        private readonly IKnifeService _knifeService;
        private readonly IMapper _mapper;

        public SalesController(IKnifeService knifeService,ISaleService saleService, IMapper mapper)
        {
            _saleService = saleService;
            _knifeService = knifeService;
            _mapper = mapper;
        }

        public IActionResult Items()
        {
            var supplies = _mapper.Map<IEnumerable<SaleDTO>, IEnumerable<SaleViewModel>>(_saleService.GetAll());
            return View(supplies);
        }

        public IActionResult Delete(int id)
        {
            _saleService.Delete(id);
            return RedirectToAction("Items");
        }

        [HttpGet]
        public IActionResult Create()
        {
            var sale = new SaleViewModel()
            {
                MaxKnifeId = _knifeService.GetAll().Max(x => x.Id)
            };
            return View(sale);
        }

        [HttpPost]
        public IActionResult Create(SaleViewModel sale)
        {
            var mappedSale = _mapper.Map<SaleViewModel, SaleDTO>(sale);
            _saleService.Add(mappedSale);
            return Ok();
        }
    }
}
