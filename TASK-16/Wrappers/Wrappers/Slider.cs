using System;
using OpenQA.Selenium;

namespace Wrappers.Wrappers;

public class Slider
{
    public static void SliderSlide(IWebElement slider,decimal input)
    {
        var steps = Convert.ToByte(input * 2);  //step is 0.5
        for (int i = 0; i < steps; i++)
        {
            slider.SendKeys(Keys.ArrowRight);
        }
    }
}
