using Code.Domain.Interfaces;
using Code.Infrastructure.Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Data.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly IDbTransaction _transaction;
        private IDbConnection Connection => _transaction.Connection;

        public BlogRepository(IDbTransaction transaction)
        {
            _transaction = transaction;
        }

        public async Task<Blogmodel> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM Blogs WHERE Id = @Id";
            return await Connection.QueryFirstOrDefaultAsync<Blogmodel>(sql, new { Id = id }, _transaction);
        }

        public async Task<IEnumerable<Blogmodel>> GetAllAsync()
        {
            var sql = "SELECT * FROM Blogs";
            return await Connection.QueryAsync<Blogmodel>(sql, transaction: _transaction);
        }

        public async Task<int> AddAsync(Blogmodel blog)
        {
            var sql = @"
                INSERT INTO Blogs (Title, Description, Isactive,Addedby,CreatedAt)
                VALUES (@Title, @Description, @Isactive,@Addedby,@CreatedAt);
                SELECT CAST(SCOPE_IDENTITY() as int)";
            var id = await Connection.ExecuteScalarAsync<int>(sql, blog, _transaction);
            blog.Id = id;
            return id;
        }

        public async Task<int> UpdateAsync(Blogmodel blog)
        {
            var sql = "UPDATE Blogs SET Name = @Name, Price = @Price, Stock = @Stock WHERE Id = @Id";
            return await Connection.ExecuteAsync(sql, blog, _transaction);
        }

        public async Task<int> DeleteAsync(int id)
        {
            var sql = "DELETE FROM Blogs WHERE Id = @Id";
            return await Connection.ExecuteAsync(sql, new { Id = id }, _transaction);
        }

        public async Task<IEnumerable<Blogmodel>> GetBlogsInStockAsync()
        {
            var sql = "SELECT * FROM Blogs WHERE Stock > 0";
            return await Connection.QueryAsync<Blogmodel>(sql, transaction: _transaction);
        }
    }
}
