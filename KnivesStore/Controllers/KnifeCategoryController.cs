using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using KnivesStore.BLL.DTO;
using KnivesStore.BLL.Interfaces;
using KnivesStore.PL.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace KnivesStore.PL.Controllers
{
    public class KnifeCategoryController : Controller
    {
        private readonly IKnifeCategoryService _knifeCategoriesService;
        private readonly IMapper _mapper;

        public KnifeCategoryController(IKnifeCategoryService knivesCategoryService, IMapper mapper)
        {
            _knifeCategoriesService = knivesCategoryService;
            _mapper = mapper;
        }

        #region Items

        public IActionResult Items()
        {
            var items = _mapper.Map<IEnumerable<KnifeCategoryDTO>, IEnumerable<KnifeCategoryViewModel>>(_knifeCategoriesService.GetAll());
            return View(items);
        }

        #endregion

        #region Create

        [HttpGet]
        public IActionResult Create()
        {
            var items = _knifeCategoriesService.GetAll();
            int newId = 1;
            if (items.Any()) newId = items.Max(x => x.Id) + 1;
            var category = new KnifeCategoryViewModel()
            {
                Id = newId
            };
            return View(category);
        }

        [HttpPost]
        public IActionResult Create(KnifeCategoryViewModel newCategory)
        {
            var item = _mapper.Map<KnifeCategoryViewModel, KnifeCategoryDTO>(newCategory);
            _knifeCategoriesService.Add(item);
            return RedirectToAction("Items");
        }

        #endregion

        #region Details

        public IActionResult Details(int? id)
        {
            var item = _mapper.Map<KnifeCategoryDTO, KnifeCategoryViewModel>(_knifeCategoriesService.Get(id));
            return View(item);
        }

        #endregion

        #region Delete

        public IActionResult Delete(int? id)
        {
            _knifeCategoriesService.Delete(id);
            return RedirectToAction("Items");
        }

            #endregion

        #region Edit

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var item = _knifeCategoriesService.GetAll().Single(x => x.Id == id);
            var mappedItem = _mapper.Map<KnifeCategoryDTO, KnifeCategoryViewModel>(item);
            return View(mappedItem);
        }

        [HttpPost]
        public IActionResult Edit(KnifeCategoryViewModel editedCategory)
        {
            var item = _mapper.Map<KnifeCategoryViewModel, KnifeCategoryDTO>(editedCategory);
            _knifeCategoriesService.Update(item);
            return RedirectToAction("Items");
        }

        #endregion
    }
}
