using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebStore.Models.Core;
using WebStore.Models.ViewModels;

namespace WebStore.Controllers
{
    public class UsersController : Controller
    {
        private readonly IMapper _mapper;
        private readonly UserManager<WebStoreUser> _userManager;

        public UsersController(IMapper mapper, UserManager<WebStoreUser> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var usersVM = await _userManager.Users
                .Select(user => _mapper.Map<UserViewModel>(user))
                .ToListAsync();

            return View(usersVM);
        }
    }
}
