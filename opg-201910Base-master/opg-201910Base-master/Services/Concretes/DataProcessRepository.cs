using Microsoft.Extensions.Options;
using opg_201910_interview.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace opg_201910_interview.Services
{
    public class DataProcessRepository : IDataProcessRepository
    {
        private readonly IOptions<List<ClientSettings>> _customClients;

        public DataProcessRepository(
            IOptions<List<ClientSettings>> customClients)
        {
            _customClients = customClients;
        }

        public async Task<ClientSettings> GetClientSettings(string id)
        {
            ClientSettings client = new ClientSettings();
            client = _customClients.Value.Where(x => x.ClientId == id).FirstOrDefault();
            return client;
        }
    }
}
