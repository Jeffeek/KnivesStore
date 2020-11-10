using KnivesStore.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KnivesStore.PL.Controllers
{
    public class CartController : Controller
    {
        private ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        public IActionResult Index()
        {
            var items = _cartService.GetAll();

            return View();
        }

        public IActionResult RemoveKnife(int id)
        {
            _cartService.Remove(id);
            return RedirectToAction("ShowBasket");
        }

        public RedirectToActionResult AddKnife(int id)
        {
            _cartService.Add(id, HttpContext.Session.GetInt32("CartId").Value);
            return RedirectToAction("ShowBasket");
        }
    }
}
