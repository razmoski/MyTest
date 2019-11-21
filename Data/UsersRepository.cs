using HighfieldTest.Data.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HighfieldTest.Data
{
    public class UsersRepository : IRepository
    {
        private readonly ILogger<UsersRepository> _logger;
        private readonly IRestClient _client;
        private readonly ApiSettings _apiSettings;

        public UsersRepository(ILogger<UsersRepository> logger,
                               IRestClient client,
                               ApiSettings apiSettings)
        {
            _logger = logger;
            _client = client;
            _apiSettings = apiSettings;
        }

        public async Task<List<UserDto>> GetUsersAsync()
        {
            return await _client.GetAsync<List<UserDto>>(_apiSettings.Uri);
        }

        public async Task SaveUsersAsync(UserColourAgesDto dto)
        {
            await _client.PostNoResponseAsync(_apiSettings.Uri, dto);
        }
    }
}
