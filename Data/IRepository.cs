using HighfieldTest.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HighfieldTest.Data
{
    public interface IRepository
    {
        Task<List<UserDto>> GetUsersAsync();

        Task SaveUsersAsync(UserColourAgesDto dto);
    }
}
