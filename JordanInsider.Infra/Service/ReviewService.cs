using JordanInsider.Core.Models;
using JordanInsider.Core.Repository;
using JordanInsider.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Review GetReviewById(decimal id)
        {
            return _reviewRepository.GetReviewById(id);
        }

        public void CreateReview(Review reviewData)
        {
            _reviewRepository.CreateReview(reviewData);
        }

        public void UpdateReview(Review reviewData)
        {
            _reviewRepository.UpdateReview(reviewData);
        }

        public void DeleteReview(decimal id)
        {
            _reviewRepository.DeleteReview(id);
        }
    }
}
