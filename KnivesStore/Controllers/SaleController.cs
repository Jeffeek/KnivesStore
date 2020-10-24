using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using KnivesStore.BLL.DTO;
using KnivesStore.BLL.Interfaces;
using KnivesStore.PL.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace KnivesStore.PL.Controllers
{
    public class SaleController : Controller
    {
        private readonly ISaleService _saleService;
        private readonly IKnifeService _knifeService;
        private readonly IMapper _mapper;

        public SaleController(IKnifeService knifeService,ISaleService saleService, IMapper mapper)
        {
            _saleService = saleService;
            _knifeService = knifeService;
            _mapper = mapper;
        }

        #region Items

        public IActionResult Items()
        {
            var supplies = _mapper.Map<IEnumerable<SaleDTO>, IEnumerable<SaleViewModel>>(_saleService.GetAll());
            return View(supplies);
        }

        #endregion

        #region Delete

        public IActionResult Delete(int id)
        {
            _saleService.Delete(id);
            return RedirectToAction("Items");
        }

        #endregion

        #region Create

            [HttpGet]
            public IActionResult Create()
            {
                int newId = 1;
                var items = _saleService.GetAll();
                if (items.Any()) newId = items.Max(x => x.Id) + 1;
                int maxKnifeId = _knifeService.GetAll().Max(x => x.Id);
                var sale = new SaleViewModel()
                {
                    Id = newId,
                    MaxKnifeId = maxKnifeId,
                    KnifeId = 1
                };
                return View(sale);
            }

            [HttpPost]
            public IActionResult Create(SaleViewModel sale)
            {
                var mappedSale = _mapper.Map<SaleViewModel, SaleDTO>(sale);
                _saleService.Add(mappedSale);
                return RedirectToAction("Items");
            }

        #endregion

        #region Details

        public IActionResult Details(int? id)
        {
            var item = _mapper.Map<SaleDTO, SaleViewModel>(_saleService.Get(id));
            return View(item);
        }

        #endregion

        #region Edit

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var item = _saleService.Get(id);
            var mappedItem = _mapper.Map<SaleDTO, SaleViewModel>(item);
            mappedItem.MaxKnifeId = _knifeService.GetAll().Max(x => x.Id);
            return View(mappedItem);
        }

        [HttpPost]
        public IActionResult Edit(SaleViewModel editedCategory)
        {
            var item = _mapper.Map<SaleViewModel, SaleDTO>(editedCategory);
            _saleService.Update(item);
            return RedirectToAction("Items");
        }

        #endregion
    }
}
