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

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.Users
                .Include(user => user.Orders)
                .ThenInclude(order => order.OrderDetails)
                .ThenInclude(orderDetail => orderDetail.Product)
                .FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            var userVM = _mapper.Map<UserDetailsViewModel>(user);

            return View(userVM);
        }
    }
}
