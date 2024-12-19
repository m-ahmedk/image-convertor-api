using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class TestApiController : ControllerBase
{
    [HttpGet]
    public string Get() => "Service is working!";
}