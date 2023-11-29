using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Models;
using OnlineShop.Models.Dto;
using OnlineShop.Services;

namespace OnlineShop.Controllers;

[Route("api/sections")]
[ApiController]
public class SectionsController : ControllerBase
{
    private readonly ISectionService sectionService;
    private readonly IMapper mapper;

    public SectionsController(ISectionService sectionService,
                              IMapper mapper)
    {
        this.sectionService = sectionService;
        this.mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetSections() {
        var sections = await sectionService.GetAllSectionsAsync();
        var sectionModels = mapper.Map<IEnumerable<SectionDto>>(sections);
        return Ok(sectionModels);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSection([FromRoute] int id) {
        var section = await sectionService.GetSectionByIdAsync(id);

        if (section == null)
            return NotFound();

        var sectionModel = mapper.Map<SectionDto>(section);
        return Ok(sectionModel);
    }

    [HttpPost]
    public async Task<IActionResult> PostSection([FromBody] CreateSectionDto dto) {
        var section = mapper.Map<Section>(dto);
        var newSection = await sectionService.CreateSectionAsync(section);
        var sectionModel = mapper.Map<SectionDto>(newSection);
        return CreatedAtAction(nameof(GetSection), new { id = sectionModel.Id }, sectionModel);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutSection([FromRoute] int id, [FromBody] UpdateSectionDto dto) {
        var section = mapper.Map<Section>(dto);
        var updatedSection = await sectionService.UpdateSectionAsync(id, section);

        if (updatedSection == null) {
            return NotFound();
        }

        return NoContent();
    }
}
