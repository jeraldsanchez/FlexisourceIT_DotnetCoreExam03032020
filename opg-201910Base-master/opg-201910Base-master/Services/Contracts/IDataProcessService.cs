using opg_201910_interview.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace opg_201910_interview.Services
{
    public interface IDataProcessService
    {
        Task<HashSet<Tuple<string, string, string>>> GetAllFileName(ClientSettings clientSettings);
    }
}
