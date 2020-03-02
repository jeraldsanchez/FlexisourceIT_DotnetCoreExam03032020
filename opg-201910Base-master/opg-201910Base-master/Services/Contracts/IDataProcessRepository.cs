using opg_201910_interview.Models;
using System.Threading.Tasks;

namespace opg_201910_interview.Services
{
    public interface IDataProcessRepository
    {
        Task<ClientSettings> GetClientSettings(string id);
    }
}
