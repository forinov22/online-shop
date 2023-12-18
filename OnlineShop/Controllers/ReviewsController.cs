using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Models.DTOs;
using OnlineShop.Services;
using System.Security.Claims;

namespace OnlineShop.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReviewsController : ControllerBase
{
    private readonly IReviewService _reviewService;

    public ReviewsController(IReviewService reviewService)
    {
        _reviewService = reviewService;
    }

    [HttpGet("product/{productId:int}")]
    public async Task<ActionResult<IEnumerable<ReviewDto>>> GetProductReviews([FromRoute] int productId)
    {
        var reviews = await _reviewService.GetAllProductReviewsAsync(productId);
        return reviews.ToList();
    }

    [HttpGet("user/{userId:int}")]
    public async Task<ActionResult<IEnumerable<ReviewDto>>> GetUserReviews([FromRoute] int userId)
    {
        var reviews = await _reviewService.GetAllUserReviewsAsync(userId);
        return reviews.ToList();
    }

    [HttpGet("{reviewId:int}")]
    public async Task<ActionResult<ReviewDto>> GetReview([FromRoute] int reviewId)
    {
        var review = await _reviewService.GetReviewByIdAsync(reviewId);
        return review == null ? NoContent() : review;
    }

    [Authorize(Roles = "User")]
    [HttpPost]
    public async Task<ActionResult<ReviewDto>> CreateReview([FromBody] ReviewAdd dto)
    {
        if (!int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int userId))
            return Forbid();

        var review = await _reviewService.CreateReviewAsync(userId, dto);
        return CreatedAtAction(nameof(GetReview), new { reviewId = review.Id }, review);
    }

    [HttpPut("{reviewId:int}")]
    public async Task<ActionResult<ReviewDto>> UpdateReview([FromRoute] int reviewId, [FromBody] ReviewUpdate dto)
    {
        var review = await _reviewService.UpdateReviewAsync(reviewId, dto);
        return review == null ? NotFound() : review;
    }

    [HttpDelete("{reviewId:int}")]
    public async Task<ActionResult> DeleteReview([FromRoute] int reviewId)
    {
        var deleted = await _reviewService.DeleteReviewAsync(reviewId);
        return deleted ? NoContent() : NotFound();
    }
}
