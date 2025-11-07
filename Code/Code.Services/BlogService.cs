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
            return await _unitOfWork.Products.GetAllAsync();
        }

        public async Task<Blogmodel> GetByIdAsync(int id)
        {
            return await _unitOfWork.Products.GetByIdAsync(id);
        }

        public async Task<int> CreateAsync(Blogmodel product)
        {
            var id = await _unitOfWork.Products.AddAsync(product);
            _unitOfWork.Commit();
            return id;
        }

        public async Task UpdateAsync(Blogmodel product)
        {
            await _unitOfWork.Products.UpdateAsync(product);
            _unitOfWork.Commit();
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.Products.DeleteAsync(id);
            _unitOfWork.Commit();
        }

        public async Task<IEnumerable<Blogmodel>> GetProductsInStockAsync()
        {
            return await _unitOfWork.Products.GetProductsInStockAsync();
        }
    }
}
