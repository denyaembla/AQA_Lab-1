using NUnit.Framework;
using Wrappers.Pages;

namespace Wrappers.Tests;

public class SliderTest : BaseTest
{
    [Test]
    public void Slider_Test()
    {
        var sliderPage = new SliderPage(Driver, true);
        
        var sliderStepsInput = 2;
        Wrappers.Slider.SliderSlide(sliderPage.Slider, sliderStepsInput);

        Assert.AreEqual(sliderStepsInput, sliderPage.Range.Text);
    }
}
