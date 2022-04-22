using Alerts_and_Waits.Pages.Waits;
using NUnit.Framework;
using OpenQA.Selenium.Interactions;

namespace Alerts_and_Waits.Tests;

public class WaitsTest : BaseTest
{
    private Actions _actions;

    [Test]
    public void OnlinerWaitTest()
    {
        var tvPage = new OnlinerTvWaitPage(Driver, true);

        tvPage.Checkboxes[0].Click();
        tvPage.Checkboxes[1].Click();
        tvPage.CompareButton.Click();

        var comparisonPage = new ComparePage(Driver, false);

        _actions = new Actions(Driver);
        _actions.MoveToElement(comparisonPage.ScreenDiagonal).Perform();
        comparisonPage.DataTipButton.Click();

        Assert.IsTrue(comparisonPage.DataTipWindow.Displayed);

        comparisonPage.DataTipButton.Click();

        Assert.IsTrue(comparisonPage.IsDataTipWindowInvisible);

        comparisonPage.FirstTvDeleteButton.Click();

        Assert.AreEqual(2, comparisonPage.TvsLeft.Count);
    }
}
