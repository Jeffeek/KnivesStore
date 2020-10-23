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
        private readonly IKnifeService _knifeService;
        private readonly ISaleService _saleService;
        private readonly IMapper _mapper;

        public SalesController(ISaleService supplyService, IKnifeService productService, IMapper mapper)
        {
            _knifeService = productService;
            _saleService = supplyService;
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
    }
}
