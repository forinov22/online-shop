using Mapster;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;
using OnlineShop.Models.DTOs;
using OnlineShop.Models.Mappers;

namespace OnlineShop.Services;

public interface IReviewService
{
    Task<IEnumerable<ReviewDto>> GetAllProductReviewsAsync(int productId);
    Task<IEnumerable<ReviewDto>> GetAllUserReviewsAsync(int userId);
    Task<ReviewDto?> GetReviewByIdAsync(int reviewId);
    Task<ReviewDto> CreateReviewAsync(int userId, ReviewAdd dto);
    Task<ReviewDto?> UpdateReviewAsync(int reviewId, ReviewUpdate dto);
    Task<bool> DeleteReviewAsync(int reviewId);
}

public class ReviewService : IReviewService
{
    private readonly OnlineShopContext _context;

    public ReviewService(OnlineShopContext context)
    {
        _context = context;
    }

    public async Task<ReviewDto> CreateReviewAsync(int userId, ReviewAdd dto)
    {
        var review = dto.AdaptToReview();
        review.UserId = userId;
        await _context.Reviews.AddAsync(review);
        await _context.SaveChangesAsync();
        var existingReview = await _context.Reviews.ProjectToType<ReviewDto>()
            .FirstAsync(r => r.Id == review.Id);
        return existingReview;
    }

    public async Task<bool> DeleteReviewAsync(int reviewId)
    {
        var existingReview = await _context.Reviews.FindAsync(reviewId);

        if (existingReview == null) return false;

        _context.Reviews.Remove(existingReview);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<ReviewDto>> GetAllProductReviewsAsync(int productId)
    {
        return await _context.Reviews.ProjectToType<ReviewDto>()
            .Where(r => r.ProductId == productId).ToListAsync();
    }

    public async Task<IEnumerable<ReviewDto>> GetAllUserReviewsAsync(int userId)
    {
        return await _context.Reviews.ProjectToType<ReviewDto>()
            .Where(r => r.UserId == userId).ToListAsync();
    }

    public async Task<ReviewDto?> GetReviewByIdAsync(int reviewId)
    {
        return await _context.Reviews.ProjectToType<ReviewDto>()
            .FirstOrDefaultAsync(r => r.Id == reviewId);
    }

    public async Task<ReviewDto?> UpdateReviewAsync(int reviewId, ReviewUpdate dto)
    {
        var existingReview = await _context.Reviews.FindAsync(reviewId);

        if (existingReview == null) return null;

        existingReview.Rating = dto.Rating;
        existingReview.Title = dto.Title;
        existingReview.Comment = dto.Comment;

        await _context.SaveChangesAsync();
        return existingReview.AdaptToDto();
    }
}
