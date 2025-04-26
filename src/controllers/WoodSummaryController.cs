using Microsoft.AspNetCore.Mvc;
using yume_api.src.repository.entities;
using yume_api.src.repository.repositories.interfaces;

namespace yume_api.src.controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WoodSummaryController : ControllerBase
    {
        private readonly IWoodSummaryRepository _repository;

        public WoodSummaryController(IWoodSummaryRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("save-summary")]
        public async Task<IActionResult> SaveSummary([FromBody] List<WoodSummary> summaries)
        {
            foreach (var summary in summaries)
            {
                await _repository.Create(summary);
            }

            return Ok();
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var summaries = await _repository.GetAllAsync();
            return Ok(summaries);
        }

        [HttpGet("by-month-category")]
        public async Task<IActionResult> GetByMonthAndCategory([FromQuery] string month, [FromQuery] string category)
        {
            var result = await _repository.GetByMonthAndCategoryAsync(month, category);
            return Ok(result);
        }
    }
}
