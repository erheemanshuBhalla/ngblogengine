using Code.Data.Repositories;
using Code.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Data.UnitofWork
{
    public class DapperUnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly IDbConnection _connection;
        private IDbTransaction _transaction;

        public IUserRepository Users { get; private set; }
        public IBlogRepository Blogs { get; private set; }

        private bool _disposed;

        public DapperUnitOfWork(IDbConnectionFactory connectionFactory)
        {
            _connection = connectionFactory.CreateConnection();
            _connection.Open();
            _transaction = _connection.BeginTransaction();

            Users = new UserRepository(_transaction);
            Blogs = new BlogRepository(_transaction);
        }

        public void Commit()
        {
            _transaction.Commit();
            ResetTransaction();
        }

        public void Rollback()
        {
            _transaction.Rollback();
            ResetTransaction();
        }

        private void ResetTransaction()
        {
            _transaction.Dispose();
            _transaction = _connection.BeginTransaction();

            Users = new UserRepository(_transaction);
            Blogs = new BlogRepository(_transaction);
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                _transaction?.Dispose();
                _connection?.Dispose();
                _disposed = true;
            }
        }
    }
}
