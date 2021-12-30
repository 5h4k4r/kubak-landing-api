using System.Net.Mime;
using KubakLandingApi.Models;
using KubakLandingApi.Repo;
using Microsoft.AspNetCore.Mvc;

namespace KubakLandingApi.Controllers;
[ApiController]
[Route("[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class ViewCounterController : ControllerBase
{
  private readonly ILogger<ViewCounterController> _logger;
  private readonly IViewCounterRepo _repo;

  public ViewCounterController(IViewCounterRepo repo, ILogger<ViewCounterController> logger)
  {
    _logger = logger;
    _repo = repo;
  }

  [HttpGet]
  public async Task<ViewCounter> GetViewCount()
  {
    return await _repo.GetViewCount();
  }
}