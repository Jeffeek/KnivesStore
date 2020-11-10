using System.Collections.Generic;
using KnivesStore.BLL.Interfaces;
using KnivesStore.PL.ViewModel.Areas.DefaultUser;
using Microsoft.AspNetCore.Mvc;

namespace KnivesStore.PL.Controllers
{
    public class BasketController : Controller
    {
        private IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public IActionResult ShowBasket()
        {
            var knives = _basketService.KnivesList;
            var knifeBasketList = new List<KnifeBasketViewModel>();
            foreach (var knife in knives)
            {
                knifeBasketList.Add(new KnifeBasketViewModel()
                {
                    Name = knife.Key.Name,
                    Price = knife.Key.Price,
                    Quantity = knife.Value
                });
            }



            return View(knifeBasketList);
        }

        public IActionResult RemoveKnife(int id)
        {
            _basketService.Remove(id);
            return RedirectToAction("ShowBasket");
        }

        public RedirectToActionResult AddKnife(int id)
        {
            _basketService.Add(id);
            return RedirectToAction("ShowBasket");
        }
    }
}
