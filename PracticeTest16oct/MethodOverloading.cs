using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

class Program2
{
    public int Add(int a, int b, int c)
    {
        return a + b + c;
    }
    public double Add(double a, double b, double c)
    {
        return a + b + c;
    }
    public static void Main(string[] args)
    {
        Program2 program2 = new Program2();

        int result1 = program2.Add(1, 2, 3);
        Console.WriteLine(result1);

        double result2 = program2.Add(1.0, 2.2, 2.3);
        Console.WriteLine(result2);
    }
}