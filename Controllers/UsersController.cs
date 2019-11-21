using AutoMapper;
using HighfieldTest.Services;
using HighfieldTest.Services.Models;
using HighfieldTest.Views.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace HighfieldTest.Controllers
{
    public class UsersController : Controller
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IService _service;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;

        public UsersController(ILogger<UsersController> logger,
                               IService service,
                               IMapper mapper,
                               IMemoryCache cache)
        {
            _logger = logger;
            _service = service;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _service.GetUsers();

            _cache.Set("users-data", users);

            var mappedModel = _mapper.Map<UserColourAges, UserColourAgesViewModel>(users);

            var user = mappedModel.Users;
            var ages = mappedModel.Ages;

            var userAges = (from u in user
                            join a in ages on u.Id equals a.UserId
                            select new UserAgesViewModel
                            {
                                Id = u.Id,
                                FirstName = u.FirstName,
                                LastName = u.LastName,
                                Email = u.Email,
                                DateOfBirth = u.DateOfBirth,
                                FavouriteColour = u.FavouriteColour,
                                OriginalAge = a.OriginalAge,
                                AgePlusTwenty = a.AgePlusTwenty,
                            }).ToList();

            var viewModel = new UserColoursViewModel
            {
                Users = userAges,
                TopColours = mappedModel.TopColours
            };

            return View(viewModel);
        }

        public async Task<IActionResult> Save()
        {
            bool isExist = _cache.TryGetValue("users-data", out UserColourAges model);

            if (!isExist)
            {
                model = await _service.GetUsers();
            }

            await _service.SaveUsers(model);

            var viewModel = _mapper.Map<UserColourAges, UserColourAgesViewModel>(model);

            return View("Index", viewModel);
        }
    }
}
