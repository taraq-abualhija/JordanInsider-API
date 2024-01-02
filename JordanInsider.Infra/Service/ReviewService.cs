using JordanInsider.Core.DTO;
using JordanInsider.Core.Models;
using JordanInsider.Core.Repository;
using JordanInsider.Core.Service;
using System;
using System.Collections.Generic;

namespace JordanInsider.Infra.Service
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public List<Review> GetAllReviews()
        {
            return _reviewRepository.GetAllReviews();
        }

        public Review GetReviewById(decimal reviewId)
        {
            return _reviewRepository.GetReviewById(reviewId);
        }

        public List<ReviewUserDTO> GetReviewsByTouristSiteId(decimal touristSiteId)
        {
            return _reviewRepository.GetReviewsByTouristSiteId(touristSiteId);
        }
        public List<Review> GetReviewsByUserId(decimal userId)
        {
            return _reviewRepository.GetReviewsByUserId(userId);
        }
        public Review GetReviewByUserId(decimal userId, decimal touristSiteId)
        {
            return _reviewRepository.GetReviewByUserId(userId, touristSiteId);
        }
        public void CreateReview(Review reviewData)
        {
            if (reviewData == null)
            {
                throw new ArgumentNullException(nameof(reviewData));
            }

            _reviewRepository.CreateReview(reviewData);
        }

        public void UpdateReview(Review reviewData)
        {
            if (reviewData == null)
            {
                throw new ArgumentNullException(nameof(reviewData));
            }

            _reviewRepository.UpdateReview(reviewData);
        }

        public void DeleteReview(decimal reviewId)
        {
            _reviewRepository.DeleteReview(reviewId);
        }
    }
}
