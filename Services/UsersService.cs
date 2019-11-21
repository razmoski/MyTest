using AutoMapper;
using HighfieldTest.Data;
using HighfieldTest.Data.Models;
using HighfieldTest.Services.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HighfieldTest.Services
{
    public class UsersService : IService
    {
        private readonly ILogger<UsersService> _logger;
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public UsersService(ILogger<UsersService> logger,
                            IRepository repository,
                            IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UserColourAges> GetUsers()
        {
            var usersDto = await _repository.GetUsersAsync();

            var mappedUsers = _mapper.Map<List<UserDto>, List<User>>(usersDto);

            List<Colour> colors = GetColours(mappedUsers);
            List<Age> ages = GetAges(mappedUsers);

            var model = new UserColourAges
            {
                Users = mappedUsers,
                Ages = ages,
                TopColours = colors
            };

            return model;
        }

        public async Task SaveUsers(UserColourAges model)
        {
            var mapped = _mapper.Map<UserColourAges, UserColourAgesDto>(model);

            await _repository.SaveUsersAsync(mapped);
        }

        private static List<Age> GetAges(List<User> mappedUsers)
        {
            return mappedUsers.Select(x => new Age()
            {
                UserId = x.Id,
                OriginalAge = CalculateAge(x.DateOfBirth),
                AgePlusTwenty = CalculateAge(x.DateOfBirth) + 20
            }).ToList();
        }

        private static List<Colour> GetColours(List<User> mappedUsers)
        {
            return mappedUsers.GroupBy(x => x.FavouriteColour)
                                                .Select(x => new Colour()
                                                {
                                                    Name = x.Key,
                                                    Count = x.Count()
                                                })
                                                .OrderByDescending(x => x.Count)
                                                .ThenBy(x => x.Name)
                                                .ToList();
        }

        private static int CalculateAge(DateTime birthdate)
        {
            var today = DateTime.Today;
            var age = today.Year - birthdate.Year;
            if (birthdate.Date > today.AddYears(-age))
                age--;

            return age;
        }
    }
}
