using JordanInsider.Core.Models;
using JordanInsider.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace JordanInsider.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService reviewService;

        public ReviewController(IReviewService reviewService)
        {
            this.reviewService = reviewService;
        }

        [HttpGet]
        [Route("GetAllReviews")]
        public IActionResult GetAllReviews()
        {
            try
            {
                var reviews = reviewService.GetAllReviews();
                return Ok(reviews);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while retrieving reviews: " + ex.Message);
            }
        }

        [HttpGet]
        [Route("GetReviewById/{id}")]
        public IActionResult GetReviewById(int id)
        {
            try
            {
                var review = reviewService.GetReviewById(id);
                if (review == null)
                    return NotFound();

                return Ok(review);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while retrieving the review: " + ex.Message);
            }
        }

        [HttpGet]
        [Route("GetReviewsByTouristSiteId/{touristSiteId}")]
        public IActionResult GetReviewsByTouristSiteId(int touristSiteId)
        {
            try
            {
                var reviews = reviewService.GetReviewsByTouristSiteId(touristSiteId);
                return Ok(reviews);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while retrieving reviews for the tourist site: " + ex.Message);
            }
        }
        [HttpGet]
        [Route("GetReviewsByUserId/{userId}")]
        public IActionResult GetReviewsByUserId(int userId)
        {
            try
            {
                var reviews = reviewService.GetReviewsByUserId(userId);
                return Ok(reviews);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while retrieving reviews for the tourist site: " + ex.Message);
            }
        }
        [HttpGet]
        [Route("GetReviewByUserId/{userId}/{touristSiteId}")]
        public IActionResult GetReviewByUserId( int userId, int touristSiteId)
        {
            try
            {
                var review = reviewService.GetReviewByUserId(userId, touristSiteId);
                return Ok(review);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while retrieving reviews for the tourist site: " + ex.Message);
            }
        }
        [HttpPost]
        [Route("CreateReview")]
        public IActionResult CreateReview(Review reviewData)
        {
            try
            {
                reviewService.CreateReview(reviewData);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while creating the review: " + ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateReview")]
        public IActionResult UpdateReview(Review reviewData)
        {
            try
            {
                reviewService.UpdateReview(reviewData);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while updating the review: " + ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteReview/{id}")]
        public IActionResult DeleteReview(int id)
        {
            try
            {
                reviewService.DeleteReview(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while deleting the review: " + ex.Message);
            }
        }
    }
}
