using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using opg_201910_interview.Models;
using opg_201910_interview.Services;

namespace opg_201910_interview.Controllers
{
    [Route("api/v1/DataProcess/[controller]")]
    public class DataProcessController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDataProcessService _dataProcessService;
        private readonly IDataProcessRepository _dataProcessRepository;

        public DataProcessController(ILogger<HomeController> logger
            ,IDataProcessRepository dataProcessRepository
            ,IDataProcessService dataProcessService)
        {
            _logger = logger;
            _dataProcessService = dataProcessService; 
            _dataProcessRepository = dataProcessRepository;
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllCustomer(string id)
        {
            try
            {
                string[] allowedFileName = null;
                List<FileNameResponse> sortedFileName = new List<FileNameResponse>();
                HashSet<Tuple<string, string, string>> hashTuple = new HashSet<Tuple<string, string, string>>();
                
                //Get Client Settings
                ClientSettings clientSettings = await _dataProcessRepository.GetClientSettings(id);
                if (clientSettings == null)
                {
                    _logger.LogError($"GetAllCustomer - Id not found: {id}");
                    return NotFound();
                }
                allowedFileName = clientSettings.FileName.ToString().Split(',');

                //Get Hash
                hashTuple = await _dataProcessService.GetAllFileName(clientSettings);

                #region Compare Hash and Sort
                //Compare Hash to allowedFileName
                var lookup = hashTuple.ToLookup(kvp => kvp.Item2);
                var result =
                    from key in allowedFileName
                    from obj in lookup[key]
                    select obj;

                foreach (var item in result)
                {
                    sortedFileName.Add(new FileNameResponse { FileName = item.Item1.ToString() });
                }
                #endregion

                return Accepted(sortedFileName);
            }
            catch (Exception ex)
            {
                _logger.LogError($"GetAllCustomer - Error: { ex.Message } {id}");
                return BadRequest();
            }
        }
    }
}