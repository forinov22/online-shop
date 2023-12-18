using Mapster;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;
using OnlineShop.Exceptions;
using OnlineShop.Models.DTOs;
using OnlineShop.Models.Mappers;

namespace OnlineShop.Services;

public interface IMediaService
{
    Task<IEnumerable<MediaDto>> GetProductMediasAsync(int productId);
    Task<MediaDto> GetMediaByIdAsync(int mediaId);
    Task<(byte[],string)> GetImageByMedaIdAsync(int mediaId);
    Task<MediaDto> CreateMediaAsync(MediaAdd dto);
    Task<MediaDto> DeleteMediaAsync(int mediaId);
}

public class MediaService : IMediaService
{
    private readonly OnlineShopContext _context;

    public MediaService(OnlineShopContext context)
    {
        _context = context;
    }

    public async Task<MediaDto> CreateMediaAsync(MediaAdd dto)
    {
        var media = dto.AdaptToMedia();

        using (var memoryStream = new MemoryStream())
        {
            await dto.File.CopyToAsync(memoryStream);
            media.Bytes = memoryStream.ToArray();
        }

        media.FileName = dto.File.Name;
        media.FileType = dto.File.ContentType;

        await _context.Medias.AddAsync(media);
        await _context.SaveChangesAsync();
        var existingMedia = await _context.Medias.ProjectToType<MediaDto>()
            .FirstAsync(m => m.Id == media.Id);
        return existingMedia;
    }

    public async Task<MediaDto> DeleteMediaAsync(int mediaId)
    {
        var existingMedia = await _context.Medias.FindAsync(mediaId);

        if (existingMedia == null)
            throw new NotFoundException(ExceptionMessages.MediaNotFound);

        _context.Medias.Remove(existingMedia);
        await _context.SaveChangesAsync();
        return existingMedia.AdaptToDto();
    }

    public async Task<(byte[], string)> GetImageByMedaIdAsync(int mediaId)
    {
        var media = await _context.Medias.FindAsync(mediaId);

        if (media == null)
            throw new NotFoundException(ExceptionMessages.MediaNotFound);

        return new(media.Bytes, media.FileType);
    }

    public async Task<MediaDto> GetMediaByIdAsync(int mediaId)
    {
        var media = await _context.Medias.ProjectToType<MediaDto>()
            .FirstOrDefaultAsync(m => m.Id == mediaId);

        if (media == null)
            throw new NotFoundException(ExceptionMessages.MediaNotFound);

        return media;
    }

    public async Task<IEnumerable<MediaDto>> GetProductMediasAsync(int productId)
    {
        return await _context.Medias.ProjectToType<MediaDto>()
            .Where(m => m.ProductId == productId).ToListAsync();
    }
}
