using Dotmim.Sync.Web.Server;
using Microsoft.AspNetCore.Mvc;

namespace LifeCRM.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SyncController : ControllerBase
{
    private readonly WebServerAgent _webServerAgent;

    // Inject the WebServerAgent registered via builder.Services.AddSyncServer(...)
    public SyncController(WebServerAgent webServerAgent)
    {
        _webServerAgent = webServerAgent;
    }

    [HttpPost]
    public async Task Post()
    {
        await _webServerAgent.HandleRequestAsync(HttpContext);
    }

    [HttpGet]
    public async Task Get()
    {
        await _webServerAgent.HandleRequestAsync(HttpContext);
    }
}