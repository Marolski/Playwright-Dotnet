using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using PlaywrightTests;

namespace PlaywrightTests;

[TestFixture]
public class RunTests 
{
    public IPage _page = Setup.Page;

    [Test]
    public async Task StronaGlowna(){
        var mainPage = new MainPage(_page);
        var menuPage = new MenuPage(_page);
        var mobileApp = new MobileApp(_page);
        await mainPage.GoToMainPage();
        await menuPage.ChooseMenuOption(nameof(MenuOptions.Aplikacja));
        await mobileApp.GotoMyAwardsSection();
    }
}