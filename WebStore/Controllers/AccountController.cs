using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using WebStore.Models.Core;
using WebStore.Models.DTOs;
using AutoMapper;

namespace WebStore.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<WebStoreUser> _signInManager;
        private readonly UserManager<WebStoreUser> _userManager;
        private readonly IMapper _mapper;

        public AccountController(SignInManager<WebStoreUser> signInManager, UserManager<WebStoreUser> userManager, IMapper mapper)
        {
            this._signInManager = signInManager;
            this._userManager = userManager;
            this._mapper = mapper;
        }

        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerVM)
        {
            if (ModelState.IsValid)
            {
                var user = _mapper.Map<WebStoreUser>(registerVM);

                var result = await _userManager.CreateAsync(user, registerVM.Password);

                if (result.Succeeded) 
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(registerVM);
        }
    }
}
