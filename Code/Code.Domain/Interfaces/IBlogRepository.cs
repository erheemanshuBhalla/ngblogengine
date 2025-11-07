using Code.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Domain.Interfaces
{
    public interface IBlogRepository : IRepository<Blogmodel>
    {
        Task<IEnumerable<Blogmodel>> GetBlogsInStockAsync();
    }
}
