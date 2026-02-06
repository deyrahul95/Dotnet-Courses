using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Interfaces;
using PersonalBlog.Models;

namespace PersonalBlog.Controllers;

public class HomeController(ILogger<HomeController> logger, IDataService service) : Controller
{
    public async Task<IActionResult> Index()
    {
        var posts = await service.GetPostsAsync();
        return View(posts);
    }

    [Route("Post")]
    [HttpGet]
    public IActionResult CreatePost(Post model)
    {
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Post(Post model)
    {
        if (ModelState.IsValid == false)
        {
            return View("CreatePost", model);
        }

        await service.CreateAsync(model);
        return RedirectToAction("Index");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        logger.LogError($"Request ID: {Activity.Current?.Id ?? HttpContext.TraceIdentifier}");
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
