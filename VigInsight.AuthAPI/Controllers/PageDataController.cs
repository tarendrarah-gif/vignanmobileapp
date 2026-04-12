using Microsoft.AspNetCore.Mvc;
using VigInsight.Core.Interfaces;

namespace VigInsight.AuthAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PageDataController : ControllerBase
    {
        private readonly IPageDataService _pageDataService;

        public PageDataController(IPageDataService pageDataService)
        {
            _pageDataService = pageDataService;
        }

        /// <summary>
        /// GET api/PageData/{pageId}
        /// Returns the latest row for the requested page number.
        /// Supported pages: 2, 3, 5, 7, 10, 11, 14, 15, 18, 20, 21, 26, 29, 32, 34, 44, 53
        /// </summary>
        [HttpGet("{pageId:int}")]
        public IActionResult GetPageData(int pageId)
        {
            try
            {
                var data = _pageDataService.GetPageData(pageId);
                if (data == null)
                    return NotFound($"No handler found for page {pageId}.");

                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error fetching page {pageId} data: {ex.Message}");
            }
        }
    }
}
