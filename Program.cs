// File name: Program.cs
// Project Name: Monte-Carlo-Method
// Author: Orndoff, Robert K.
// Date created: 07/18/2019
// Date last modified: 07/18/2019
/*----Questions and Answers----
1. Why do we multiply the value from step 5 above by 4?
   **Because of the 4 quadrants of a circle.**

2. What do you observe in the output when running your program with parameters of increasing size?
   **The value gets closer to Pi**

3. If you run the program multiple times with the same parameter, does the output remain the same? Why or why not?
   **It does not. Because of the random input seed.**

4. Find a parameter that requires multiple seconds of run time. What is that parameter?
   **1,000,000**

5. How accurate is the estimated value of pi?
   **Fairly close: 0.00211534641020705**

6. Research one other use of Monte-Carlo methods.  Record it in your exercise submission and be prepared to discuss it in class.
  **The US Coast Guard uses Monte-Carlo methods for computational modeling in order to assist with probable location of lost 
    vessles at sea during search and rescure.**
*/
// C#
using System;

namespace Monte_Carlo_Method
{
    class Program
    {
        static void Main(string[] args)

        {
            //Steps 1,2,3:
            int iterations = Convert.ToInt32(args[0]);
            int counter = 0;

            //Step 4:
            for(int i = 0; i < iterations; i++)
            {
                double hypotenuse = Hypotenuse(UniformlyDistrubited());
                if (hypotenuse <= 1)
                {
                    ++counter;
                }
            }
            //Step 5:
            double value = 4.0 * counter / iterations ;

            //Step 6:
            Console.WriteLine($"Estimated Pi: {value}");
            Console.WriteLine($"Delta: {Math.Abs(value - Math.PI)}");
        }
        static Tuple<double, double> UniformlyDistrubited()
        {
            double firstNumber = 0;
            double secondNumber = 0;
            Random rando = new Random();
            firstNumber = Convert.ToSingle(rando.NextDouble());
            secondNumber = Convert.ToSingle(rando.NextDouble());
            var distributedNumbers = new Tuple<double, double>(firstNumber, secondNumber);
            return distributedNumbers;
        }
        static double Hypotenuse(Tuple<double, double> distributedNumbers)
        {
            double hypotenuse = Math.Sqrt(Math.Pow(distributedNumbers.Item1, 2) + Math.Pow(distributedNumbers.Item2, 2));
            return hypotenuse;
        }

    }
}
