using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Data.Repositories
{
    public abstract class BaseRepository<T>
    {
        protected readonly IDbTransaction _transaction;
        protected IDbConnection Connection => _transaction.Connection;
        protected readonly string _tableName;

        protected BaseRepository(IDbTransaction transaction, string tableName)
        {
            _transaction = transaction;
            _tableName = tableName;
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            var sql = $"SELECT * FROM {_tableName} WHERE Id = @Id";
            return await Connection.QueryFirstOrDefaultAsync<T>(sql, new { Id = id }, _transaction);
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            var sql = $"SELECT * FROM {_tableName}";
            return await Connection.QueryAsync<T>(sql, transaction: _transaction);
        }

        public virtual async Task<int> DeleteAsync(int id)
        {
            var sql = $"DELETE FROM {_tableName} WHERE Id = @Id";
            return await Connection.ExecuteAsync(sql, new { Id = id }, _transaction);
        }
    }
}
