using Microsoft.AspNetCore.Mvc;
using OnlineShop.Models.DTOs;
using OnlineShop.Services;

namespace OnlineShop.Controllers;

[Route("api/sections")]
[ApiController]
public class SectionsController : ControllerBase
{
    private readonly ISectionService _sectionService;

    public SectionsController(ISectionService sectionService)
    {
        _sectionService = sectionService;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<SectionDto>>> GetSections()
    {
        var sections = await _sectionService.GetAllSectionsAsync();
        return sections.ToList();
    }

    [HttpGet("{sectionId:int}")]
    public async Task<ActionResult<SectionDto>> GetSection([FromRoute] int sectionId)
    {
        var section = await _sectionService.GetSectionByIdAsync(sectionId);
        return section;
    }

    [HttpPost]
    public async Task<ActionResult<SectionDto>> CreateSection([FromBody] SectionAdd dto)
    {
        var section = await _sectionService.CreateSectionAsync(dto);
        return section;
    }

    [HttpPut("{sectionId:int}")]
    public async Task<ActionResult<SectionDto>> UpdateSection([FromRoute] int sectionId, [FromBody] SectionUpdate dto)
    {
        var section = await _sectionService.UpdateSectionAsync(sectionId, dto);
        return section;
    }
    
    [HttpDelete("{sectionId:int}")]
    public async Task<ActionResult<SectionDto>> DeleteSection([FromRoute] int sectionId)
    {
        var deleted = await _sectionService.DeleteSectionAsync(sectionId);
        return deleted;
    }
}