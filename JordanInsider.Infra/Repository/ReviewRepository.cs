using Dapper;
using JordanInsider.Core.Common;
using JordanInsider.Core.DTO;
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
            IEnumerable<Review> result = dbContext.Connection.Query<Review>("review_package.GetAllReviews", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Review GetReviewById(decimal reviewId)
        {
            var p = new DynamicParameters();
            p.Add("p_reviewId", reviewId, DbType.Int32, ParameterDirection.Input);
            var result = dbContext.Connection.Query<Review>("review_package.GetReviewById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
      

        public List<ReviewUserDTO> GetReviewsByTouristSiteId(decimal touristSiteId)
        {
            var p = new DynamicParameters();
            p.Add("p_touristSiteId", touristSiteId, DbType.Int32, ParameterDirection.Input);
            var result = dbContext.Connection.Query<ReviewUserDTO>("review_package.GetReviewsByTouristSiteId", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<Review> GetReviewsByUserId(decimal userId)
        {
            var p = new DynamicParameters();
            p.Add("p_userId", userId, DbType.Int32, ParameterDirection.Input);
            var result = dbContext.Connection.Query<Review>("review_package.GetReviewsByUserId", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Review GetReviewByUserId(decimal userId, decimal touristSiteId)
        {
            var p = new DynamicParameters();
            p.Add("p_touristSiteId", touristSiteId, DbType.Int32, ParameterDirection.Input);

            p.Add("p_userId", userId, DbType.Int32, ParameterDirection.Input);
            var result = dbContext.Connection.Query<Review>("review_package.GetReviewByUserId", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void CreateReview(Review reviewData)
        {
            var p = new DynamicParameters();
            p.Add("p_touristSiteId", reviewData.Touristsiteid, DbType.Int32, ParameterDirection.Input);
            p.Add("p_userId", reviewData.Userid, DbType.Int32, ParameterDirection.Input);
            p.Add("p_rating", reviewData.Rating, DbType.Decimal, ParameterDirection.Input);
            p.Add("p_reviewText", reviewData.Reviewtxt, DbType.String, ParameterDirection.Input);
            var result = dbContext.Connection.Execute("review_package.CreateReview", p, commandType: CommandType.StoredProcedure);
        }

        public void UpdateReview(Review reviewData)
        {
            var p = new DynamicParameters();
            p.Add("p_reviewId", reviewData.Reviewid, DbType.Int32, ParameterDirection.Input);
            p.Add("p_rating", reviewData.Rating, DbType.Int32, ParameterDirection.Input);
            p.Add("p_reviewText", reviewData.Reviewtxt, DbType.String, ParameterDirection.Input);
            var result = dbContext.Connection.Execute("review_package.UpdateReview", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteReview(decimal reviewId)
        {
            var p = new DynamicParameters();
            p.Add("p_reviewId", reviewId, DbType.Int32, ParameterDirection.Input);
            var result = dbContext.Connection.Execute("review_package.DeleteReview", p, commandType: CommandType.StoredProcedure);
        }
    }
}
