using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class EntriesCommands : IEntriesCommands
    {
        private readonly IEntriesRepository _entriesRepository;
        public EntriesCommands(IEntriesRepository entriesRepository)
        {
            _entriesRepository = entriesRepository;
        }
        public async Task<_Entries> GetEntriesByHttpsNode(bool request)
        {
            _Entries entries = await _entriesRepository.GetEntriesByHttpsNode(request);
            return entries;
        }
        
        public async Task<IEnumerable<string>> GetEntriesByDistinctCategoryNode()
        {
            IEnumerable<string> entries = await _entriesRepository.GetEntriesByDistinctCategoryNode();
            return entries;
        }
    }
}
