using JordanInsider.Core.DTO;
using JordanInsider.Core.Models;
using System;
using System.Collections.Generic;

namespace JordanInsider.Core.Repository
{
    public interface IReviewRepository
    {
        List<Review> GetAllReviews();
        Review GetReviewById(decimal reviewId);
        List<ReviewUserDTO> GetReviewsByTouristSiteId(decimal touristSiteId);
        public List<Review> GetReviewsByUserId(decimal userId);
        public Review GetReviewByUserId(decimal userId, decimal touristSiteId);
        void CreateReview(Review reviewData);
        void UpdateReview(Review reviewData);
        void DeleteReview(decimal reviewId);
    }
}
