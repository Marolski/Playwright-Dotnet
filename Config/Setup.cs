using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace PlaywrightTests;

[SetUpFixture]
public class Setup 
{
    private static IPage _page;
    private IBrowser browser;
    public static IPage Page => _page;

    [OneTimeSetUp]
    public async Task SetupPage()
    {
        //Select browser and configuration
        var playwright = await Playwright.CreateAsync();
        browser = await playwright.Firefox.LaunchAsync(new BrowserTypeLaunchOptions{
            Headless = false
        });
        _page = await browser.NewPageAsync();
        await _page.GotoAsync("https://mcdonalds.pl");
    }

    [OneTimeTearDown]
    public async Task TearDownPage(){
        await browser.CloseAsync();
    }
}