using Alerts_and_Waiters.Pages.WindowManage;
using NUnit.Framework;

namespace Alerts_and_Waiters.Tests;

public class MultiWindowTest : BaseTest
{
    [Test]
    [Category("Homework")]
    public void WindowsHandlingTest()
    {
        var windowsTest = new OnlinerTvWindowPage(Driver, true);
        
        windowsTest.VkFooterLink.Click();
        windowsTest.FbFooterLink.Click();
        windowsTest.TwFooterLink.Click();
        
        var allWindowHandles = Driver.WindowHandles;
            
        Driver.SwitchTo().Window(allWindowHandles[1]);
        var twPage = new TwitterPage(Driver, false);
        Assert.Multiple(() =>
        {
            Assert.IsTrue(twPage.TwitterLogo.Displayed);
            Assert.IsTrue(twPage.MainOnlinerTitle.Text.Contains("onlíner"));
        });
        twPage.ExploreButton.Click();
            
        Driver.SwitchTo().Window(allWindowHandles[2]);
        var fbPage = new FacebookPage(Driver, false);
        Assert.Multiple(() =>
        {
            Assert.IsTrue(fbPage.FacebookHeader.Displayed);
            Assert.IsTrue(fbPage.OnlinerTitle.Text.Contains("onlíner"));
        });
        fbPage.FirstAboutTab.Click();
            
        Driver.SwitchTo().Window(allWindowHandles[3]);
        var vkPage = new VkPage(Driver, false);
        Assert.Multiple(() =>
        {
            Assert.IsTrue(vkPage.VkHeader.Displayed);
            Assert.IsTrue(vkPage.OnlinerVkGroupTitle.Text.ToLower().Normalize().Equals("onlíner"));
        });
        vkPage.VkSignInButton.Click();
    }
}
