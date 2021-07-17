using System.Collections.Generic;
using System.Data;
using System.Linq;
using Chat.Models;
using Dapper;


namespace Chat.Repositories
{
    public class UserRepository
    {
        private readonly IDbConnection db;
        private readonly IDbTransaction transaction;

        public UserRepository(IDbConnection db, IDbTransaction transaction)
        {
            this.db = db;
            this.transaction = transaction;   
        }
        
        public IList<User> GetAll() 
        {
            return this.db.Query<User>("Select * From [User]").ToList();
        }

        public void Save(User user) {
            string sql = "INSERT INTO [USER](Username, Password) OUTPUT INSERTED.Id VALUES(@Username, @Password)";

            user.Id = this.db.ExecuteScalar<long>(sql, new {Username = user.Username, Password = user.Password}, transaction: transaction);
        }
    }
}