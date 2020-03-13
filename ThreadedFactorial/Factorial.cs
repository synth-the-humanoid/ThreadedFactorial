using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Numerics;

namespace ThreadedFactorial
{
    class Factorial
    {
        private static Dictionary<uint, BigInteger> cache = new Dictionary<uint, BigInteger>();     // cache of previous values
        private uint value = 0;                                                                     // the value to calculate

        // the factorial of value
        public BigInteger Result
        {
            get
            {
                // if result isnt in cache
                if (!cache.ContainsKey(value))
                {
                    Thread t = new Thread(GetFactorial); // start a new thread to calculate it
                    t.Start();
                    t.Join();                            // and wait for it to save the value to cache
                }
                return cache[value];                     // then return the value from cache
            }
        }

        // instantiate a factorial object and set the cache if not yet set
        public Factorial(uint value)
        {
            this.value = value;
            
            if (cache.ContainsKey(0))
                return;

            cache.Add(0, BigInteger.One);
            cache.Add(1, BigInteger.One);
        }

        // recursively calculates the factorial of value and saves it to cache
        private void GetFactorial()
        {
            Factorial nminusone = new Factorial(value - 1);
            BigInteger result = nminusone.Result * value;
            cache.TryAdd(value, result);
        }

    }
}
