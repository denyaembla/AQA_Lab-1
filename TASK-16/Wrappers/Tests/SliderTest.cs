using System;
using NUnit.Framework;
using Wrappers.Pages;

namespace Wrappers.Tests;

public class SliderTest : BaseTest
{
    [Test]
    public void Slider_Test()
    {
        var sliderPage = new SliderPage(Driver, true);

        var middle = 3.5m;
        var minimum = 0m;
        var maximum = 5m;


        Wrappers.Slider.SliderSlideByValue(sliderPage.Slider, sliderPage, sliderPage.Range.Text, middle);

        Assert.AreEqual("3.5", sliderPage.Range.Text);

        Wrappers.Slider.SliderSlideByValue(sliderPage.Slider, sliderPage, sliderPage.Range.Text, minimum);

        Assert.AreEqual("0", sliderPage.Range.Text);

        Wrappers.Slider.SliderSlideByValue(sliderPage.Slider, sliderPage, sliderPage.Range.Text, maximum);

        Assert.AreEqual("5", sliderPage.Range.Text);
    }
}
