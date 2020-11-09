using KnivesStore.BLL.DTO;
using KnivesStore.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KnivesStore.PL.Controllers
{
    public class BasketController : Controller
    {
        private IKnifeService _knifeService;
        private KnifeDTO Knife;

        public BasketController(IKnifeService knifeService)
        {
            _knifeService = knifeService;
        }

        public IActionResult UpdateBasket(int? id)
        {
            var knife = _knifeService.Get(id);
            return View(knife);
        }


        public IActionResult ShowBasket()
        {
            return View(Knife);
        }
    }
}
