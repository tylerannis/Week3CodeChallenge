using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3CodeChallenge
{
    class Program
    {
        //make a list of primes and add in the primes you know
        public static List<int> primes = new List<int>() { 2, 3 };

        static void Main(string[] args)
        {
            //calling primes
            FindNPrimes(10001);

            //Calling EvenFibs
            EvenFibonacciSequencer(89);

            //Call LongCollatz
            LongestCollatzSequence();

            //keep the console open
            Console.ReadKey();
        }
        static void FindNPrimes(int maxPrime)
        {

            //make number for the IsPrime to check can't be even because i'm going up by 2 and no even number is prime
            int numToCheck = 5;
            //make a loop for getting to maxPrime
            while (primes.Count < maxPrime)
            {
                //calling IsPrime function
                IsPrime(numToCheck);
                numToCheck += 2;

            }
            Console.WriteLine("The " + maxPrime + " prime number is " + primes.Last());
        }
        static void IsPrime(int number)
        {
            //make a loop to check prime numbers
            bool prime = true;
            //set what you are incrementing which is index i of list of primes
            int i = 0;
            //Math.Floor to get a non decimal point and the prime number is less than the square root of number we are checking
            while (prime && primes[i] <= Math.Floor(Math.Sqrt(number)))
            {
                //only check if divisable by prime numbers in list,
                //can divide by list index because you started with 2 and 3 in your list
                if (number % primes[i] == 0)
                {
                    prime = false;
                }
                i++;
            }
            if (prime)
            {
                primes.Add(number);
            }
        }
        static void EvenFibonacciSequencer(int maxValue)
        {
            //made a list and added the two starting numbers to it
            List<int> fiblist = new List<int>() { 1, 2 };
            //set incrementor for while loop
            int i = 0;
            //set value to hold next fib number
            int hold = 0;
            //set value to hold evens
            int output = 0;
            //loop through list until the last value equals maxValue
            while (fiblist.Last() < maxValue)
            {
                //add the two values and put the output in hold
                hold = fiblist[i] + fiblist[i + 1];

                fiblist.Add(hold);
                //add one to i
                i++;
                //if even
                if (fiblist[i] % 2 == 0)
                {
                    //add index to output
                    output += fiblist[i];
                }
            }
            //print output
            Console.WriteLine("All even numbers added: " + output);
        }
        static void LongestCollatzSequence()
        {
            //keep track of the number that starts the chain and the longest chain
            long highestChain = 1;
            long highestNumber = 1;
            //loop from 1 to 1,000,000
            for (int i = 1; i <= 1000000; i++)
            {
                //set your start point for the while loop
                long startpoint = i;
                //set a variable to count sequence length
                int length = 0;
                //make the condition of the while the number doesn't equal 1
                while (startpoint != 1)
                {
                    //see if i is even
                    if (startpoint % 2 == 0)
                    {
                        startpoint /= 2;
                        length += 1;
                    }
                    else
                    {
                        startpoint = (startpoint * 3) + 1;
                        length += 1;
                    }
                }
                if (length > highestChain)
                {
                    highestChain = length;
                    highestNumber = i;
                }
            }
            Console.WriteLine("The number that gives the longest chain is " + highestNumber + ", the chain is " + highestChain + " numbers long.");
        }
    }
}
