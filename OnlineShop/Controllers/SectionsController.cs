using Microsoft.AspNetCore.Mvc;
using OnlineShop.Models.DTOs.OnlineShop.Domains;
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
        return Ok(sections);
    }

    [HttpGet("{sectionId:int}")]
    public async Task<ActionResult<SectionDto>> GetSection([FromRoute] int sectionId)
    {
        var section = await _sectionService.GetSectionByIdAsync(sectionId);
        
        if (section == null)
            return NotFound();
        
        return Ok(section);
    }

    [HttpPost]
    public async Task<ActionResult<SectionDto>> CreateSection([FromBody] SectionAdd dto)
    {
        var section = await _sectionService.CreateSectionAsync(dto);
        return Ok(section);
    }

    [HttpPut("{sectionId:int}")]
    public async Task<ActionResult<SectionDto>> UpdateSection([FromRoute] int sectionId, [FromBody] SectionUpdate dto)
    {
        var updatedSection = await _sectionService.UpdateSectionAsync(sectionId, dto);

        if (updatedSection == null)
            return NotFound();

        return Ok(updatedSection);
    }
    
    [HttpDelete("{sectionId:int}")]
    public async Task<ActionResult<ColorDto>> DeleteSection([FromRoute] int sectionId)
    {
        var deleted = await _sectionService.DeleteSectionAsync(sectionId);
        
        if (!deleted)
            return NotFound();
        
        return NoContent();
    }
}