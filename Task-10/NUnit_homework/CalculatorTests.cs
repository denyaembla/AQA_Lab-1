using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
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

    [OneTimeSetUp]
    [Ignore("Testing Attributes")]
    public void OneTimeSetupToIgnore()
    {
        Console.WriteLine("This line should not be logged...");
    }

    [Property("Priority", 1)]
    [Category("Calculator")]
    [Order(1)]
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
        Assert.AreNotEqual(result, first);
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

    [Test]
    public void TestForOtherAsserts()
    {
        var listForAssert = new List<int>
        {
            1,
            2
        };

        var number1 = 13;
        var number2 = number1;

        int? nullObject = null;

        var someEmptyString = string.Empty;

        Assert.Multiple(() =>
        {
            Assert.Contains(2, listForAssert, "List 'listForAssert' contains int value of 2.");
            Assert.IsNull(nullObject);
            Assert.IsEmpty(someEmptyString);
            Assert.IsTrue(someEmptyString == string.Empty);
            Assert.Greater(listForAssert[1], listForAssert[0]);
        });
        
        Assert.AreNotSame(listForAssert[0], listForAssert[1]);
        Assert.AreSame(listForAssert, listForAssert);

        number2++;
        Assert.AreNotEqual(number1, number2);
    }

    [Test]
    public void TestTo_Fail()
    {
        Assert.Fail();
    }
    
    [Test]
    public void TestTo_Pass()
    {
        Assert.Pass();
    }
    
    [Test]
    public void TestTo_Ignore()
    {
        Assert.Ignore();
    }
    
    [Test]
    public void TestTo_AssertInconclusive()
    {
        Assert.Inconclusive();
    }

    [Test]
    public void TestTo_AssertThat()
    {
        void Hello() => Console.WriteLine("Hey");

        TestDelegate mes = Hello;

        var ex = Assert.Throws<Exception>(() => throw new Exception("message"));

        Assert.That(ex.Message, Is.EqualTo("message"));
        Assert.DoesNotThrow(mes);
    }
    
    
    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        Console.WriteLine("OneTimeTearDown...");
    }

    [TearDown]
    public void TearDown()
    {
        Console.WriteLine("Teardown...");
    }
}
