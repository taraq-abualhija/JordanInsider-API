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
    public class LoginRepository : ILoginRepository
    {
        private readonly IDbContext dbContext;
        public LoginRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public User GenerateToken(User user)
        {
            var p = new DynamicParameters();
            p.Add("User_NAME", user.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("PASS", user.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Query<User>("Login_Package.User_Login", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
    }
}
