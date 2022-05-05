using System;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Allure_Reporting.Extensions;

public static class MyExtensions
{
    
    public static string SimpleCensor(this String text, string badWord)
    {
        var random = new Random();
        StringBuilder sb = new StringBuilder(text);
        Span<char> wordToCensor = badWord.ToCharArray();
        for (var i = 0; i <= wordToCensor.Length - 1; i += 2)
        {
            wordToCensor[(int) random.NextInt64(0, wordToCensor.Length - 1)] = '#';
            wordToCensor[(int) random.NextInt64(0, wordToCensor.Length - 1)] = '%';
        }

        var replacementWord = new string(wordToCensor);
        var result = sb.Replace(badWord, replacementWord).ToString();
        return result;
    }
}
