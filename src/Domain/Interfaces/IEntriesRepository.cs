using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IEntriesRepository
    {
        Task<_Entries> GetEntriesByHttpsNode(bool request);
        Task<IEnumerable<string>> GetEntriesByDistinctCategoryNode();
    }
}
