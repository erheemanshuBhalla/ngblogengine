using Code.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Domain.Interfaces
{
    public interface IUserRepository : IRepository<Usermodel>
    {
        /* Respoir*/
        Task<Usermodel> GetByEmailAsync(string email);
    }
}
