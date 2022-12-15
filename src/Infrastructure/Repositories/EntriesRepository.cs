using Domain.Entities;
using Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class EntriesRepository : IEntriesRepository
    {
        private readonly ILogger<EntriesRepository> _logger;
        private readonly IConfiguration _configuration;
        public EntriesRepository(ILogger<EntriesRepository> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }
        public async Task<_Entries> GetEntriesByHttpsNode(bool request)
        {
            _Entries entries = new _Entries();
            string _urlApi = $"{_configuration["UrlEntries"]}";
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_urlApi);
                    client.DefaultRequestHeaders.Accept.Clear();
                    var responseMessage = await client.GetAsync(_urlApi);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        var response = responseMessage.Content.ReadAsStringAsync().Result;
                        _Entries _entries = JsonConvert.DeserializeObject<_Entries>(response);
                        var entriesList = _entries.Entries.Where(x => x.Https == request).ToList();
                        entries.Count = entriesList.Count();
                        entries.Entries = entriesList;
                        return entries;
                    }
                }
            }
            catch(Exception e)
            {
                _logger.LogError($"Error in GetEntriesByHttpsNode Method: {e.Message}");
                throw new ApplicationException(e.Message);
            }
            return entries;
        }
        public async Task<IEnumerable<string>> GetEntriesByDistinctCategoryNode()
        {
            string _urlApi = $"{_configuration["UrlEntries"]}";
            List<string> categories = new List<string>();
            IEnumerable<string> distinctCategories = null;

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_urlApi);
                    client.DefaultRequestHeaders.Accept.Clear();
                    var responseMessage = await client.GetAsync(_urlApi);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        var response = responseMessage.Content.ReadAsStringAsync().Result;
                        _Entries _entries = JsonConvert.DeserializeObject<_Entries>(response);
                        foreach (var entries in _entries.Entries)
                        {
                            categories.Add(entries.Category);
                        }
                        return distinctCategories = categories.Distinct();
                    }
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in GetEntriesByDistinctCategoryNode Method: {e.Message}");
                throw new ApplicationException(e.Message);
            }

            return distinctCategories;
        }
    }
}
