using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Models.DTOs;
using OnlineShop.Services;

namespace OnlineShop.Controllers;

[Route("api/medias")]
[ApiController]
public class MediasController : ControllerBase
{
    private readonly IMediaService _mediaService;

    public MediasController(IMediaService mediaService)
    {
        _mediaService = mediaService;
    }

    [HttpGet("product/{productId:int}")]
    public async Task<ActionResult<IEnumerable<MediaDto>>> GetProductMedias([FromRoute] int productId)
    {
        var medias = await _mediaService.GetProductMediasAsync(productId);
        return medias.ToList();
    }

    [HttpGet("{mediaId:int}")]
    public async Task<ActionResult<MediaDto>> GetMedia(int mediaId)
    {
        var media = await _mediaService.GetMediaByIdAsync(mediaId);
        return media;
    }

    [HttpGet("{mediaId:int}/image")]
    public async Task<ActionResult> GetMediaImage([FromRoute] int mediaId)
    {
        var (bytes, filetype) = await _mediaService.GetImageByMedaIdAsync(mediaId);
        return File(bytes, filetype);
    }

    [HttpPost]
    public async Task<ActionResult<MediaDto>> CreateMedia([FromForm] MediaAdd dto)
    {
        var media = await _mediaService.CreateMediaAsync(dto);
        return media;
    }

    [HttpDelete("{mediaId:int}")]
    public async Task<ActionResult<MediaDto>> DeleteMedia(int mediaId)
    {
        var deleted = await _mediaService.DeleteMediaAsync(mediaId);
        return deleted;
    }
}
