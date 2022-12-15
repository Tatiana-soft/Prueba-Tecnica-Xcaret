using API.Infrastructure.ApiResult;
using Application.Commands;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EntriesController : ControllerBase
    {
        private readonly IEntriesCommands _entriesCommands;
        private readonly ILogger<EntriesController> _logger;
        public EntriesController(ILogger<EntriesController> logger, IEntriesCommands entriesCommands)
        {
            _logger = logger;
            _entriesCommands = entriesCommands;
        }
        [Route("getEntriesByHttpsNode")]
        [HttpGet]
        public async Task<ActionResult<_Entries>> GetEntriesByHttpsNode([FromQuery] bool request)
        {
            var entries = await _entriesCommands.GetEntriesByHttpsNode(request);
            if (entries == null)
            {
                string message = $"Can't find any entry with value Https: {request}";
                _logger.LogError(message);
                return new NotFoundObjectResult(new ErrorResponse(HttpStatusCode.NotFound.ToString(), message));
            }
            return entries;
        }

        [Route("getEntriesByDistinctCategoryNode")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> GetEntriesByDistinctCategoryNode()
        {
            IEnumerable<string> categories = await _entriesCommands.GetEntriesByDistinctCategoryNode();
            if (categories == null)
            {
                string message = $"Can't find any categories";
                _logger.LogError(message);
                return new NotFoundObjectResult(new ErrorResponse(HttpStatusCode.NotFound.ToString(), message));
            }
            return categories.ToList();
        }
    }
}
