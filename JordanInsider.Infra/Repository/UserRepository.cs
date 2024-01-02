using Dapper;
using JordanInsider.Core.Common;
using JordanInsider.Core.Models;
using JordanInsider.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JordanInsider.Infra.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbContext dbContext;

        public UserRepository(IDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }

        public List<User> GetAllUsers()
        {
            IEnumerable<User> result = dbContext.Connection.Query<User>("user_package.GetAllUsers", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public User GetUserById(decimal userId)
        {
            var p = new DynamicParameters();
            p.Add("p_userId", userId, DbType.Int32, ParameterDirection.Input);
            var result = dbContext.Connection.Query<User>("user_package.GetUserById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void CreateUser(User userData)
        {
            var p = new DynamicParameters();
            p.Add("p_name", userData.Name, DbType.String, ParameterDirection.Input);
            p.Add("p_Image", userData.Imagename, DbType.String, ParameterDirection.Input);

            p.Add("p_email", userData.Email, DbType.String, ParameterDirection.Input);
            p.Add("p_phoneNum", userData.Phonenum, DbType.String, ParameterDirection.Input);
            p.Add("p_password", userData.Password, DbType.String, ParameterDirection.Input);

            p.Add("p_roleid", userData.Roleid, DbType.Int32, ParameterDirection.Input);

            var result = dbContext.Connection.Execute("user_package.CreateUser", p, commandType: CommandType.StoredProcedure);
        }

        public void UpdateUser(User userData)
        {
            var p = new DynamicParameters();
            p.Add("p_userId", userData.Userid, DbType.Int32, ParameterDirection.Input);
            p.Add("p_name", userData.Name, DbType.String, ParameterDirection.Input);
            p.Add("p_Image", userData.Imagename, DbType.String, ParameterDirection.Input);

            p.Add("p_email", userData.Email, DbType.String, ParameterDirection.Input);
            p.Add("p_phoneNum", userData.Phonenum, DbType.String, ParameterDirection.Input);
            p.Add("p_password", userData.Password, DbType.String, ParameterDirection.Input);
            var result = dbContext.Connection.Execute("user_package.UpdateUser", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteUser(decimal userId)
        {
            var p = new DynamicParameters();
            p.Add("p_userId", userId, DbType.Int32, ParameterDirection.Input);
            var result = dbContext.Connection.Execute("user_package.DeleteUser", p, commandType: CommandType.StoredProcedure);
        }

    }
}
