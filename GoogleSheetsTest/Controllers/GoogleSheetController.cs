using Microsoft.AspNetCore.Mvc;

namespace GoogleSheetsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GoogleSheetController : ControllerBase
    {
        private readonly GoogleSheetsService _sheetsService;

        // Constructor-based Dependency Injection
        public GoogleSheetController(GoogleSheetsService sheetsService)
        {
            _sheetsService = sheetsService;
        }

        [HttpGet]
        public IActionResult GetGoogleSheetData()
        {
            try
            {
                string spreadSheetId = "1gnO-PzQ-OWQXEizQtG7UfvfWpmeZTlFm2EJxViuIQSM";
                string range = "Class Data!A2:E";

                var data = _sheetsService.GetGoogleSheetData(spreadSheetId, range);

                if (data == null || data.Count == 0)
                {
                    return NotFound("Ingen data hittades i Google Sheet.");
                }

                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ett fel uppstod: {ex.Message}");
            }
        }
    }
}
