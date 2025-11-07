using Code.Domain.Interfaces;
using Code.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Services
{
    public class BlogService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BlogService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Blogmodel>> GetAllAsync()
        {
            return await _unitOfWork.Blogs.GetAllAsync();
        }

        public async Task<Blogmodel> GetByIdAsync(int id)
        {
            return await _unitOfWork.Blogs.GetByIdAsync(id);
        }

        public async Task<int> CreateAsync(Blogmodel product)
        {
            var id = await _unitOfWork.Blogs.AddAsync(product);
            _unitOfWork.Commit();
            return id;
        }

        public async Task UpdateAsync(Blogmodel product)
        {
            await _unitOfWork.Blogs.UpdateAsync(product);
            _unitOfWork.Commit();
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.Blogs.DeleteAsync(id);
            _unitOfWork.Commit();
        }

        public async Task<IEnumerable<Blogmodel>> GetProductsInStockAsync()
        {
            return await _unitOfWork.Blogs.GetBlogsInStockAsync();
        }
    }
}
