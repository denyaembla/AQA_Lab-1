using System;

namespace NUnit_homework;


public class Calculator
{
    public int Add(int first, int second)
    {
        return first + second;
    }
    
    public int Substract(int first, int second)
    {
        return first - second;
    }

    public int Multiply(int first, int second)
    {
        return first * second;
    }

    public (int Result, int Remainder) Divide(int first, int second)
    {
        if (second == 0)
        {
            throw new DivideByZeroException();
        }
        var result = first / second;
        var remainder = first % second;
        return (result, remainder);
    }
}
