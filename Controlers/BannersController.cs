using Microsoft.AspNetCore.Mvc;
using SkodaApi.Models;
using SkodaApi.Services;

namespace SkodaApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BannersController : ControllerBase
{
  private readonly BannerService _service;
  private readonly IWebHostEnvironment _env;

  public BannersController(BannerService service, IWebHostEnvironment env)
  {
    _service = service;
    _env = env;
  }

  [HttpGet]
  public async Task<ActionResult<IEnumerable<Banner>>> Get() =>
      Ok(await _service.GetAllAsync());

  [HttpGet("{id}")]
  public async Task<ActionResult<Banner>> GetById(int id)
  {
    var banner = await _service.GetByIdAsync(id);
    return banner is null ? NotFound() : Ok(banner);
  }

  [HttpPost]
  public async Task<ActionResult<Banner>> Create(Banner banner)
  {
    var created = await _service.AddAsync(banner);
    return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> Update(int id, Banner banner)
  {
    if (id != banner.Id) return BadRequest();
    await _service.UpdateAsync(banner);
    return NoContent();
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> Delete(int id)
  {
    await _service.DeleteAsync(id);
    return NoContent();
  }

  [HttpPost("upload")]
  public async Task<IActionResult> UploadImage(IFormFile file)
  {
    if (file == null || file.Length == 0)
      return BadRequest("No file uploaded.");

    var uploadsPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");

    if (!Directory.Exists(uploadsPath))
      Directory.CreateDirectory(uploadsPath);

    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
    var filePath = Path.Combine(uploadsPath, fileName);

    await using (var stream = System.IO.File.Create(filePath))
    {
      await file.CopyToAsync(stream);
    }

    var fileUrl = $"{Request.Scheme}://{Request.Host}/uploads/{fileName}";
    return Ok(new { url = fileUrl });
  }
}