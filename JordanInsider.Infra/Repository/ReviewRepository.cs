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
    public class ReviewRepository : IReviewRepository
    {
        private readonly IDbContext dbContext;

        public ReviewRepository(IDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }

        public List<Review> GetAllReviews()
        {
            IEnumerable<Review> result = dbContext.Connection.Query<Review>("Review_Package.GetAllReviews", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Review GetReviewById(decimal id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Query<Review>("Review_Package_SPEC.GetReviewById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void CreateReview(Review reviewData)
        {
            var p = new DynamicParameters();
            p.Add("TOURISTSITEID", reviewData.Touristsiteid, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("USERID", reviewData.Userid, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("RATING", reviewData.Rating, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("REVIEWTXT", reviewData.Reviewtxt, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Execute("Review_Package_SPEC.CreateReview", p, commandType: CommandType.StoredProcedure);
        }

        public void UpdateReview(Review reviewData)
        {
            var p = new DynamicParameters();
            p.Add("ID", reviewData.Reviewid, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("TOURISTSITEID", reviewData.Touristsiteid, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("USERID", reviewData.Userid, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("RATING", reviewData.Rating, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("REVIEWTXT", reviewData.Reviewtxt, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Execute("Review_Package_SPEC.UpdateReview", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteReview(decimal id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Execute("Review_Package_SPEC.DeleteReview", p, commandType: CommandType.StoredProcedure);
        }
    }

}
