using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;


namespace PlaywrightTests;


public class MenuPage: PageTest
{
    IPage _page;
    private readonly ILocator navbar;
    private readonly ILocator stronaGlownaButton;
    private readonly ILocator naszeMenuButton;
    private readonly ILocator aplikacjaMcDonaldButton;
    private readonly ILocator restauracjeButton;
    private readonly ILocator mcDeliveryButton;
    private readonly ILocator dlaRodzinyButton;
    private readonly ILocator oMcDonaldButton;
    private static String URL = "https://mcdonalds.pl/";
    public MenuPage(IPage page)
    {
        _page = page;
        navbar = _page.Locator("//a[contains(@href,'#navbars')]");
        stronaGlownaButton = _page.GetByRole(AriaRole.Link,new(){Name=MenuOptions.StronaGlowna, Exact = true});
        naszeMenuButton = _page.GetByRole(AriaRole.Link,new(){Name=MenuOptions.NaszeMenu, Exact = true});
        aplikacjaMcDonaldButton = _page.GetByRole(AriaRole.Link,new(){Name=MenuOptions.Aplikacja, Exact = true});
        restauracjeButton = _page.GetByRole(AriaRole.Link,new(){Name=MenuOptions.Restauracje, Exact = true});
        mcDeliveryButton = _page.GetByRole(AriaRole.Link,new(){Name=MenuOptions.McDelivery, Exact = true});
        dlaRodzinyButton = _page.GetByRole(AriaRole.Link,new(){Name=MenuOptions.DlaRodziny, Exact = true});
        oMcDonaldButton = _page.GetByRole(AriaRole.Link,new(){Name=MenuOptions.OMcDonalds, Exact = true});

    }
    public async Task ChooseMenuOption(String option)
    {
        await navbar.ClickAsync();
        switch(option)
        {
            case nameof(MenuOptions.StronaGlowna):
            await stronaGlownaButton.ClickAsync();
            await Expect(_page).ToHaveURLAsync(URL);
            break;

            case nameof(MenuOptions.NaszeMenu):
            await naszeMenuButton.ClickAsync();
            await Expect(_page).ToHaveURLAsync(URL+"nasze-menu/");
            break;

            case nameof(MenuOptions.Aplikacja):
            await aplikacjaMcDonaldButton.ClickAsync();
            await Expect(_page).ToHaveURLAsync(URL+"aplikacja-mobilna/");
            break;

            case nameof(MenuOptions.Restauracje):
            await restauracjeButton.ClickAsync();
            await Expect(_page).ToHaveURLAsync(URL+"restauracje/");
            break;

            case nameof(MenuOptions.McDelivery):
            await mcDeliveryButton.ClickAsync();
            await Expect(_page).ToHaveURLAsync(URL+"mcdelivery/");
            break;

            case nameof(MenuOptions.DlaRodziny):
            await dlaRodzinyButton.ClickAsync();
            await Expect(_page).ToHaveURLAsync(URL+"dla-rodziny/");
            break;

            case nameof(MenuOptions.OMcDonalds):
            await oMcDonaldButton.ClickAsync();
            await Expect(_page).ToHaveURLAsync(URL+"o-mcdonalds/");
            break;
            
        }
    }
}