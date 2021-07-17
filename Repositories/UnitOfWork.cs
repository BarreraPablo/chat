using System.Data;
using System.Data.SqlClient;
using Chat.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Chat.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private string connectionString;
        private IDbConnection db;
        private IDbTransaction transaction;
        private UserRepository _userRepository;

        public UserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(this.db, this.transaction);
                }
                return _userRepository;
            }
        }

        public UnitOfWork(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("SqlServer");
        }

        public void Open()
        {
            this.db = new SqlConnection(connectionString);
            db.Open();
        }

        public void BeginTransaction()
        {
            if (this.db == null)
                Open();

            this.transaction = db.BeginTransaction();
        }

        public void Commit()
        {
            if (this.transaction == null)
                throw new System.Exception();

            this.transaction.Commit();
        }

        public void Rollback()
        {
            if (this.transaction == null)
                throw new System.Exception();

            this.transaction.Rollback();
        }
    }
}