﻿using System;
using System.Numerics;

namespace InterfaceTask
{

    class Program
    {
        static void TestAPlusBSquare<T>(T a, T b) where T : IMyNumber<T>
        {
            Console.WriteLine("=== Starting testing (a+b)^2=a^2+2ab+b^2 with a = " + a + ", b = " + b + " ===");
            T aPlusB = a.Add(b);
            Console.WriteLine("a = " + a);
            Console.WriteLine("b = " + b);
            Console.WriteLine("(a + b) = " + aPlusB);
            Console.WriteLine("(a+b)^2 = " + aPlusB.Multiply(aPlusB));
            Console.WriteLine(" = = = ");
            T curr = a.Multiply(a);
            Console.WriteLine("a^2 = " + curr);
            T wholeRightPart = curr;
            curr = a.Multiply(b); // ab
            curr = curr.Add(curr); // ab + ab = 2ab
            // I’m not sure how to create constant factor "2" in more elegant way,
            // without knowing how IMyNumber is implemented
            Console.WriteLine("2*a*b = " + curr);

            wholeRightPart = wholeRightPart.Add(curr);
            curr = b.Multiply(b);
            Console.WriteLine("b^2 = " + curr);
            wholeRightPart = wholeRightPart.Add(curr);
            Console.WriteLine("a^2+2ab+b^2 = " + wholeRightPart);
            Console.WriteLine("=== Finishing testing (a+b)^2=a^2+2ab+b^2 with a = " + a + ", b = " + b + " ===");
        }

        static void TestSquaresDifference<T>(T a, T b) where T : IMyNumber<T>
        {
            Console.WriteLine("=== Starting testing (a-b)^2 = a^2 - 2ab + b^2 with a = " + a + ", b = " + b + " ===");
            T aMinusB = a.Subtract(b);
            Console.WriteLine("a = " + a);
            Console.WriteLine("b = " + b);
            Console.WriteLine("(a - b) = " + aMinusB);
            Console.WriteLine("(a-b)^2 = " + aMinusB.Multiply(aMinusB));
            Console.WriteLine(" = = = ");

            T curr = a.Multiply(a);
            Console.WriteLine("a^2 = " + curr);
            T wholeRightPart = curr;

            curr = a.Multiply(b); // ab
            curr = curr.Add(curr); // ab + ab = 2ab
            Console.WriteLine("2*a*b = " + curr);

            wholeRightPart = wholeRightPart.Subtract(curr); // a^2 - 2ab
            curr = b.Multiply(b);
            Console.WriteLine("b^2 = " + curr);
            wholeRightPart = wholeRightPart.Add(curr); // a^2 - 2ab + b^2

            Console.WriteLine("a^2 - 2ab + b^2 = " + wholeRightPart);
            Console.WriteLine("=== Finishing testing (a-b)^2 = a^2 - 2ab + b^2 with a = " + a + ", b = " + b + " ===");
        }


        static void Main(string[] args)
        {
            TestAPlusBSquare(new MyFrac(1, 3), new MyFrac(1, 6));
            TestAPlusBSquare(new MyComplex(1, 3), new MyComplex(1, 6));

            TestSquaresDifference(new MyFrac(1, 3), new MyFrac(1, 6));
            TestSquaresDifference(new MyComplex(1, 3), new MyComplex(1, 6));

            var fractions = new[] { new MyFrac(1, 2), new MyFrac(3, 4), new MyFrac(1, 3) };
            Array.Sort(fractions);
            Console.WriteLine("Sorted fractions:");
            foreach (var frac in fractions)
                Console.WriteLine(frac);

            Console.ReadKey();
        }
    }
}