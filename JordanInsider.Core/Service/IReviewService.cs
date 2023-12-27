using JordanInsider.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JordanInsider.Core.Service
{
    public interface IReviewService
    {
        List<Review> GetAllReviews();
        Review GetReviewById(decimal id);
        void CreateReview(Review reviewData);
        void UpdateReview(Review reviewData);
        void DeleteReview(decimal id);
    }
}
