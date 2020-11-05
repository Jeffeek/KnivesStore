using System.Collections.Generic;
using System.Security.Claims;
using AutoMapper;
using KnivesStore.BLL.DTO;
using KnivesStore.BLL.Interfaces;
using KnivesStore.PL.ViewModel.Binding_Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace KnivesStore.PL.Controllers.AccountControllers
{
    public class RegistrationController : Controller
    {
        private IUserService _userService;
        private IMapper _mapper;

        public RegistrationController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SignUp(UserRegistrationBindingModel model)
        {
            if (ModelState.IsValid)
            {
                var mapped = _mapper.Map<UserRegistrationBindingModel, UserDTO>(model);
                _userService.Add(mapped);
                Authenticate(mapped);
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("SignUp");
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
    }
}
