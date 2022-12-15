using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    public interface IEntriesCommands
    {
        Task<_Entries> GetEntriesByHttpsNode(bool request);
        Task<IEnumerable<string>> GetEntriesByDistinctCategoryNode();
    }
}
