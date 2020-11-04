using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.Configuration.Conventions;
using KnivesStore.BLL.DTO;
using KnivesStore.BLL.Interfaces;
using KnivesStore.PL.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace KnivesStore.PL.Controllers
{
    public class KnifeController : Controller
    {
        private readonly IKnifeService _knifeService;
        private readonly IKnifeCategoryService _knifeCategoryService;
        private readonly IProducerService _producerCategoryService;
        private readonly IMapper _mapper;

        public KnifeController(IKnifeCategoryService knifeCategoryService, IProducerService producerCategoryService, IKnifeService productService, IMapper mapper)
        {
            _knifeService = productService;
            _knifeCategoryService = knifeCategoryService;
            _producerCategoryService = producerCategoryService;
            _mapper = mapper;
        }


        #region admin features

        #region Items

        public IActionResult Items()
        {
            var supplies = _mapper.Map<IEnumerable<KnifeDTO>, IEnumerable<KnifeViewModel>>(_knifeService.GetAll());
            return View(supplies);
        }

        #endregion

        #region Delete

        public IActionResult Delete(int? id)
        {
            _knifeService.Delete(id);
            return RedirectToAction("Items");
        }

        #endregion

        #region Details

        public IActionResult Details(int? id)
        {
            var item = _mapper.Map<KnifeDTO, KnifeViewModel>(_knifeService.Get(id));
            return View(item);
        }

        #endregion

        #region Create

        [HttpGet]
        public IActionResult Create()
        {
            int newId = 1;
            var items = _knifeService.GetAll();
            if (items.Any()) newId = items.Max(x => x.Id) + 1;
            var knife = new KnifeViewModel()
            {
                Id = newId,
                MaxCategoryId = _knifeCategoryService.GetAll().Max(x => x.Id),
                MaxProducerId = _producerCategoryService.GetAll().Max(x => x.Id),
            };
            return View(knife);
        }

        [HttpPost]
        public IActionResult Create(KnifeViewModel knife)
        {
            var mappedKnife = _mapper.Map<KnifeViewModel, KnifeDTO>(knife);
            _knifeService.Add(mappedKnife);
            return RedirectToAction("Items");
        }

        #endregion

        #region Edit

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var item = _knifeService.Get(id);
            var mappedItem = _mapper.Map<KnifeDTO, KnifeViewModel>(item);
            mappedItem.MaxCategoryId = _knifeCategoryService.GetAll().Max(x => x.Id);
            mappedItem.MaxProducerId = _producerCategoryService.GetAll().Max(x => x.Id);
            return View(mappedItem);
        }

        [HttpPost]
        public IActionResult Edit(KnifeViewModel editedCategory)
        {
            var item = _mapper.Map<KnifeViewModel, KnifeDTO>(editedCategory);
            _knifeService.Update(item);
            return RedirectToAction("Items");
        }

        #endregion

        #endregion

        #region user features

        public IActionResult MoveToKnifePage(KnifePanelViewModel knife)
        {
            return Details(knife.Id);
        }

        public IActionResult KnifeStoreItems()
        {
            var items = _knifeService.GetAll();
            var mapped = _mapper.Map<IEnumerable<KnifeDTO>, IEnumerable<KnifePanelViewModel>>(items);
            var imgPaths = _knifeService.GetImagesPaths(items.ToList());
            for (int i = 0; i < mapped.Count(); i++)
                mapped.ElementAt(i).ImagePath = imgPaths[i];
            return View(mapped);
        }

        #endregion
    }
}
