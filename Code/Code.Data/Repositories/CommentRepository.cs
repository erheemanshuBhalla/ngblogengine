using Code.Domain.Interfaces;
using Code.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Data.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        public Task<int> AddAsync(Blogmodel entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Blogmodel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Blogmodel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Blogmodel>> GetCommentLikes()
        {
            throw new NotImplementedException();
        }

        public Task<int> LikeComment(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(Blogmodel entity)
        {
            throw new NotImplementedException();
        }
    }
}
