using Code.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Domain.Interfaces
{
    public interface ICommentRepository : IRepository<Blogmodel>
    {
        Task<IEnumerable<Blogmodel>> GetCommentLikes();
        Task<int> LikeComment(int id);
    }
}
