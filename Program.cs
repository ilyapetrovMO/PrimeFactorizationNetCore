namespace PrimeFactorization
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter a non prime number: ");
            string userInput = Console.ReadLine();

            int userNumber;
            while (!int.TryParse(userInput, out userNumber))
            {
                System.Console.WriteLine();
                System.Console.Write("insert a valid number: ");
                userInput = System.Console.ReadLine();
            }

            System.Console.WriteLine(PrimeFactorization(userNumber));
        }

        public static string PrimeFactorization(int number)
        {
            if (IsPrime(number))
            {
                return number.ToString();
            }

            foreach (var prime in Primes())
            {
                if (number % prime == 0)
                {
                    if (IsPrime(number / prime))
                    {
                        return $"{prime} x {(number / prime).ToString()}";
                    }
                    else
                    {
                        return $"{prime} x {PrimeFactorization(number / prime)}";
                    }
                }
            }

            return "bruh";
        }

        public static IEnumerable<int> Primes()
        {
            for (int i = 2; i < int.MaxValue; i++)
            {
                if (IsPrime(i))
                {
                    yield return i;
                }
            }
        }

        public static bool IsPrime(int number)
        {
            if (number <= 1)
            {
                return false;
            }

            if (number == 2)
            {
                return true;
            }

            if (number % 2 == 0)
            {
                return false;
            }

            int boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
