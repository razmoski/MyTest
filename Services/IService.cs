using HighfieldTest.Services.Models;
using System.Threading.Tasks;

namespace HighfieldTest.Services
{
    public interface IService
    {
        Task<UserColourAges> GetUsers();

        Task SaveUsers(UserColourAges model);
    }
}
