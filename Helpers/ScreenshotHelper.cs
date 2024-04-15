using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Playwright;
namespace PlaywrightTests;

public class ScreenshotHelper
{
    private readonly IPage _page;

    public ScreenshotHelper(IPage page)
    {
        _page = page; 
    }

    public async Task TakeScreenshot()
    {
        try
        {
            DateTime now = DateTime.Now;

            string projectDirectory = Directory.GetCurrentDirectory();
            
            /* If you have a few levels to go above you can go step to step
            string pathToDebug = Directory.GetParent(projectDirectory).FullName;
            string pathToBin = Directory.GetParent(pathToDebug).FullName;
            string pathToAssets = Directory.GetParent(pathToBin).FullName; */

            //If you wanna have universal solution to chnage current directory path
            string pathToAssets ="";
            int LevelsAboveCurrentDirectory = 3;
            for (int i = 0; i<LevelsAboveCurrentDirectory; i++){
                if (LevelsAboveCurrentDirectory == 0) return;
                pathToAssets = Directory.GetParent(projectDirectory).FullName;
                projectDirectory = pathToAssets;
            }

            string filePath = Path.Combine(pathToAssets+"\\Assets", $"{now.ToString("yyyy-MM-dd HH-mm-ss")}.png");
            await _page.ScreenshotAsync(new PageScreenshotOptions { Path = filePath });
            Console.WriteLine($"Screenshot taken: {filePath}");
        }
        catch (PlaywrightException ex)
        {
            Console.WriteLine($"Error taking screenshot: {ex.Message}");
        }
    }
}
