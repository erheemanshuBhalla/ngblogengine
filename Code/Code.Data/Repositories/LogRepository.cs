using Code.Domain.Entities;
using Code.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Data.Repositories
{
    public class LogRepository : IlogRepository
    {
        public Task<int> AddAsync(Logmodel entity)
        {
            throw new NotImplementedException();
        }
    }
}
