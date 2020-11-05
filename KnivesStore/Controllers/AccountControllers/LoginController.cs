using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using KnivesStore.BLL.DTO;
using KnivesStore.BLL.Interfaces;
using KnivesStore.PL.ViewModel.Binding_Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KnivesStore.PL.Controllers.AccountControllers
{
    public class LoginController : Controller
    {
        private IUserService _userService;
        private IMapper _mapper;

        public LoginController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LogIn(UserLoginBindingModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _userService.GetAll().FirstOrDefault(u => u.Login == model.Login &&
                                                                     u.Password == model.Password);
                if (user != null)
                {
                    Authenticate(user); // аутентификация
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }

        private void Authenticate(UserDTO user)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.ToString())
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        [Authorize(Roles = "Moderator, Admin")]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        //не знаю как, но оно как то работает
        //TODO: потом убрать, это для проверки
        [Authorize(Roles = "Admin")]
        public IActionResult RolePage()
        {
            string role = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value;
            ViewBag.Role = role;
            return View("Role");
        }
    }
}
