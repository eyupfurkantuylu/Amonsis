using AmonsisTestCase.Models.Dtos.UserDtos;
using AmonsisTestCase.Repositories.UserRepositories;
using Microsoft.AspNetCore.Mvc;

namespace AmonsisTestCase.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _userRepository.ReadUserListAsync();

            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _userRepository.GetUserById(id);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(UpdateUserDto updateUserDto)
        {
            var result = await _userRepository.UpdateUserAsync(updateUserDto);

            return RedirectToAction("Index", "User");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int userId)
        {
            var result = await _userRepository.DeleteUserAsync(userId);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserDto userDto)
        {
            await _userRepository.CreateUserAsync(userDto);

            return RedirectToAction("Index", "Home");
        }

    }
}
