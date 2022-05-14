using OpenQA.Selenium;

namespace BDDHomework.Pages;

public class MilestonesNavigationPage : BasePage
{
    private static readonly By PageTitleLocator = By.CssSelector(".content-header-title");
    private static readonly By DeleteButtonLocator = By.CssSelector(".icon-small-delete");
    private static readonly By NoMilestonesYetMessageLocator = By.CssSelector(".empty-title");
    private static readonly By DialogOkButtonLocator = By.CssSelector(".ui-dialog .button-ok");

    public IWebElement PageTitle => WaitService.WaitUntilElementExists(PageTitleLocator);

    public IWebElement DeleteButton => WaitService.WaitUntilElementExists(DeleteButtonLocator);

    public IWebElement NoMilestonesYetMessage => WaitService.WaitUntilElementExists(NoMilestonesYetMessageLocator);

    public IWebElement DialogOkButton => WaitService.WaitUntilElementExists(DialogOkButtonLocator);

    public MilestonesNavigationPage(IWebDriver driver) : base(driver)
    {
    }

    private static By MilestoneNameLocator(string milestoneName) =>
        By.XPath($"//* [@class = 'summary-title text-ppp'] // * [text() = '{milestoneName}']");

    public IWebElement MilestoneName(string milestoneName) =>
        WaitService.WaitUntilElementExists(MilestoneNameLocator(milestoneName));

    protected override By GetPageIdentifier()
    {
        return PageTitleLocator;
    }
}
