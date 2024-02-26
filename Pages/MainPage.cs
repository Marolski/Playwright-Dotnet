using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using NUnit.Framework.Internal;
using PlaywrightTests;

namespace PlaywrightTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class MainPage : PageTest
{
    private IPage _page;
    private readonly ILocator cookiesPage;
    private readonly ILocator cookiesPageElement;
    private readonly ILocator logo;
    public MainPage(IPage page){
        _page = page;
        cookiesPage = _page.GetByText("Zgoda");
        cookiesPageElement = _page.GetByRole(AriaRole.Button, new(){Name = "Zezwól na niezbędne"});
        logo = _page.GetByAltText("Logo McDonald's®").First;

    }
    public async Task GoToMainPage()
    {

        // Expect an attribute "is visible".
        await Expect(cookiesPage).ToBeVisibleAsync();

        await cookiesPageElement.ClickAsync();

        //Expect the logo element is vivible
        await Expect(logo).ToBeVisibleAsync();

    }
}