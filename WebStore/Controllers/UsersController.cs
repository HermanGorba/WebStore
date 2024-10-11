using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebStore.Models.Core;
using WebStore.Models.DTOs;
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

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserDTO createUserDTO) 
        {
            if (ModelState.IsValid)
            {
                var user = _mapper.Map<WebStoreUser>(createUserDTO);
                var result = await _userManager.CreateAsync(user, createUserDTO.Password);

                if (result.Succeeded)
                    return RedirectToAction(nameof(Index));

                foreach (var error in result.Errors)
                    ModelState.AddModelError(string.Empty, error.Description);
            }
            return View(createUserDTO);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
                return NotFound();

            var user = await _userManager.FindByIdAsync(id.Value.ToString());

            if (user == null)
                return NotFound();

            var editUserDTO = _mapper.Map<EditUserDTO>(user);

            return View(editUserDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, EditUserDTO editUserDTO)
        {
            if (id != editUserDTO.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var user = await _userManager
                    .FindByIdAsync(editUserDTO.Id.ToString());

                if (user == null)
                {
                    return NotFound();
                }

                _mapper.Map(editUserDTO, user);

                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(editUserDTO);
        }

    }
}
