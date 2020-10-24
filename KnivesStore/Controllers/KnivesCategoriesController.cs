using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using KnivesStore.BLL.DTO;
using KnivesStore.BLL.Interfaces;
using KnivesStore.PL.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace KnivesStore.PL.Controllers
{
    public class KnivesCategoriesController : Controller
    {
        private readonly IKnifeCategoryService _knifeCategoriesService;
        private readonly IMapper _mapper;

        public KnivesCategoriesController(IKnifeCategoryService knivesCategoryService, IMapper mapper)
        {
            _knifeCategoriesService = knivesCategoryService;
            _mapper = mapper;
        }

        public IActionResult Items()
        {
            var items = _mapper.Map<IEnumerable<KnifeCategoryDTO>, IEnumerable<KnifeCategoryViewModel>>(_knifeCategoriesService.GetAll());
            return View(items);
        }

        [HttpGet]
        public IActionResult Create()
        {
            int newId = _knifeCategoriesService.GetAll().Max(x => x.Id) + 1;
            var category = new KnifeCategoryViewModel() {Id = newId};
            return View(category);
        }

        [HttpPost]
        public IActionResult Create(KnifeCategoryViewModel newCategory)
        {
            var item = _mapper.Map<KnifeCategoryViewModel, KnifeCategoryDTO>(newCategory);
            _knifeCategoriesService.Add(item);
            return RedirectToAction("Items");
        }

        public IActionResult Delete(int? id)
        {
            _knifeCategoriesService.Delete(id);
            return RedirectToAction("Items");
        }

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
    }
}
