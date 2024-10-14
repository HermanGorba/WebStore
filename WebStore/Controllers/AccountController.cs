using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebStore.Models.Core;
using WebStore.Models.ViewModels;

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

        public async Task<IActionResult> Login(string? returnUrl)
        {
            var loginVM = new LoginViewModel()
            {
                ReturnUrl = returnUrl ?? string.Empty
            };

            return View(loginVM);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginVM)
        {
            if (!ModelState.IsValid)
            {
                return View(loginVM);
            }
            
            var user = await _userManager.FindByEmailAsync(loginVM.Email);

            if (user == null)
            {
                return View(loginVM);
            }

            var result = await _signInManager
                .PasswordSignInAsync(user, loginVM.Password, loginVM.RememberMe, false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Incorrect login or password!");
                return View(loginVM);
            }

            if (!string.IsNullOrEmpty(loginVM.ReturnUrl) && Url.IsLocalUrl(loginVM.ReturnUrl))
            {
                return Redirect(loginVM.ReturnUrl);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
