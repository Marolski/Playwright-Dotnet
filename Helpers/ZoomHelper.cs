using System;
using System.Threading.Tasks;
using Microsoft.Playwright;
namespace PlaywrightTests;

public class ZoomHelper
{
    private readonly IPage _page;

    public ZoomHelper(IPage page)
    {
        _page = page;
    }

    //If you wannt to zoom in you should pass percent more than 100, 
    //if zoom out pass percent less than 100
    //It works on IE and Chromium, doesnt work on Firefox
    public async Task Zoom(string percent)
    {
        try
        {
            await _page.EvaluateAsync($"document.body.style.zoom = '{percent}%'");
            Console.WriteLine("Zoomed in");
        }
        catch (PlaywrightException ex)
        {
            Console.WriteLine($"Error zooming in: {ex.Message}");
        }
    }
}