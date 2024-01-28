


using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace CallFileProcessor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CallLogsController : ControllerBase
    {
        private readonly IHostApplicationLifetime _applicationLifetime;
        private readonly IFileWatcher _fileWatcher;

        public CallLogsController(IHostApplicationLifetime applicationLifetime, IFileWatcher fileWatcher)
        {
            _applicationLifetime = applicationLifetime;
            _fileWatcher = fileWatcher;
        }

        [HttpPost]
        public IActionResult StartFileProcessing()
        {
            try
            {
                _fileWatcher.StartFileWatcher();
                return Ok("Dosya izlemesi başlatıldı.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Bir hata oluştu: {ex.Message}");
            }
        }
    }
}
