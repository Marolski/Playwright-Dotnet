using System;
using System.Threading.Tasks;
using Microsoft.Playwright;
namespace PlaywrightTests;

public class ScrollHelper
{
    private readonly IPage _page;

    public ScrollHelper(IPage page)
    {
        _page = page;
    }

    public async Task ScrollToElementById(ILocator locator)
    {
        try
        {
            await locator.ScrollIntoViewIfNeededAsync();
            Console.WriteLine($"Scrolled to element");
        }
        catch (PlaywrightException ex)
        {
            Console.WriteLine($"Error scrolling to element: {ex.Message}");
        }
    }
}