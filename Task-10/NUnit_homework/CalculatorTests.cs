using System;
using NUnit.Framework;

namespace NUnit_homework;

[TestFixture]
[Category("SmokeTest")]
[Author("Denis")]
public class Tests
{
    private Calculator _calculator;

    [SetUp]
    public void SetUp()
    {
        Console.WriteLine("Setup...");
    }

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        Console.WriteLine("OneTimeSetup...");
        _calculator = new Calculator();
    }

    [Property("Priority", 1)]
    [Category("Calculator")]
    [TestCase(10, 1, 11)]
    [TestCase(-5, -3, -8)]
    [TestCase(110, 90, 200)]
    public void Test_Add(int first, int second, int result)
    {
        var actual = _calculator.Add(first, second);

        Assert.AreEqual(result, actual);
    }

    [Property("Priority", 2)]
    [TestCase(11, 6, 5)]
    [TestCase(35, 36, -1)]
    [TestCase(-5, 6, -11)]
    [TestCase(-3, -10, 7)]
    public void TestSubtract(int first, int second, int result)
    {
        var actual = _calculator.Subtract(first, second);

        Assert.AreEqual(result, actual);
    }

    [Property("Priority", 3)]
    [TestCase(1, 10000, 10000)]
    [TestCase(-10, -5, 50)]
    [TestCase(-2, 2, -4)]
    [TestCase(35, 0, 0)]
    public void TestMultiply(int first, int second, int result)
    {
        var actual = _calculator.Multiply(first, second);

        Assert.AreEqual(result, actual);
    }
    
    [Property("Priority", 3)]
    [TestCase(6.66, 0.06, 111)]
    [TestCase(-10.05, 20.10, -0.5)]
    [TestCase(-2.36, -0.472, 5)]
    [TestCase(0, 0.0001, 0)]
    public void TestDoubleDivide(double first, double second, double result)
    {
        var actual = _calculator.Divide(first, second);

        Assert.AreEqual(result, actual);
    }

    [Property("Priority", 4)]
    [TestCase(32, 6, 5, 2)]
    [TestCase(10, 6, 1, 4)]
    [TestCase(8, 8, 1, 0)]
    public void TestDivide(int first, int second, int result, int remainder)
    {
        var tuple = _calculator.Divide(first, second);

        Assert.Multiple(() =>
        {
            Assert.AreEqual(result, tuple.Result);
            Assert.AreEqual(remainder, tuple.Remainder);
            // Assert.Ignore("Ignoring...");
        });
    }

    [Property("Severity", 5)]
    [TestCase(10, 0)]
    [TestCase(0, 0)]
    [Ignore("Some reason why")]
    public void TestDivideByZero(int first, int second)
    {
        try
        {
            var actual = _calculator.Divide(first, second);
        }
        catch (DivideByZeroException goodException)
        {
            Assert.Pass();
        }
        catch (Exception badException)
        {
            Assert.Fail();
        }
    }

    [TearDown]
    public void TearDown()
    {
        Console.WriteLine("Teardown...");
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        Console.WriteLine("OneTimeTearDown...");
    }
}
