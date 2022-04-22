using System;
using OpenQA.Selenium;
using Wrappers.Pages;

namespace Wrappers.Wrappers;

public class Slider
{
    public static void SliderSlideByValue(IWebElement slider, SliderPage sliderPage, string starting, decimal moveTo)
    {
        if (moveTo < Convert.ToDecimal(slider.GetAttribute("min")) ||
            moveTo > Convert.ToDecimal(slider.GetAttribute("max")))
            throw new ArgumentOutOfRangeException(nameof(moveTo));

        var target = moveTo;
        var current = Convert.ToDecimal(starting);

        while (current != Convert.ToDecimal(target))
        {
            if (current < target)
                slider.SendKeys(Keys.ArrowRight);
            else
                slider.SendKeys(Keys.ArrowLeft);

            current = Convert.ToDecimal(sliderPage.Range.Text);
        }
    }
}
