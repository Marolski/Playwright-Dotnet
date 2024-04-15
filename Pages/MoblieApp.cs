using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace PlaywrightTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class MobileApp: PageTest
{
    private IPage _page;
    private readonly ILocator myAwardsSection;
    private readonly ILocator myDealsYeahSection;
    private ScrollHelper scrollHelper;
    private ZoomHelper zoomHelper;

    public MobileApp(IPage page){
        _page = page;
        myAwardsSection = _page.Locator("id=3w1-mojem-nagrody-sekcja-opisowa");
        myDealsYeahSection = _page.Locator("id=3w1-mojem-okazyeah-sekcja-opisowa");
        scrollHelper = new ScrollHelper(page);
        zoomHelper = new ZoomHelper(page);
    }

    public async Task GotoMyAwardsSection(){
        await scrollHelper.ScrollToElementById(myDealsYeahSection);
        await zoomHelper.Zoom("200");
        await _page.PauseAsync();
    }
}