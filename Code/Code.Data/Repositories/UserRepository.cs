using Code.Domain.Entities;
using Code.Domain.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Data.Repositories
{
    public class UserRepository : BaseRepository<Usermodel>, IUserRepository
    {
        public UserRepository(IDbTransaction transaction)
            : base(transaction, "Users") { }

        public async Task<int> AddAsync(Usermodel user)
        {
            var sql = @"INSERT INTO Users (Email, Name) 
                    VALUES (@Email, @Name); 
                    SELECT CAST(SCOPE_IDENTITY() as int)";
            var id = await Connection.ExecuteScalarAsync<int>(sql, user, _transaction);
            user.UserId = id;
            return id;
        }

        public async Task<int> UpdateAsync(Usermodel user)
        {
            var sql = "UPDATE Users SET Email = @Email, Name = @Name WHERE Id = @Id";
            return await Connection.ExecuteAsync(sql, user, _transaction);
        }

        public async Task<Usermodel> GetByEmailAsync(string email)
        {
            var sql = "SELECT * FROM Users WHERE Email = @Email";
            return await Connection.QueryFirstOrDefaultAsync<Usermodel>(sql, new { Email = email }, _transaction);
        }
    }
}
