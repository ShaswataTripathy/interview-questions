﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

namespace CDSPractical
{
    public class Questions
    {
        /// <summary>
        /// Given an enumerable of strings, attempt to parse each string and if 
        /// it is an integer, add it to the returned enumerable.
        /// 
        /// For example:
        /// 
        /// ExtractNumbers(new List<string> { "123", "hello", "234" });
        /// 
        /// ; would return:
        /// 
        /// {
        ///   123,
        ///   234
        /// }
        /// </summary>
        /// <param name="source">An enumerable containing words</param>
        /// <returns> list containing only numbers else empty </returns>
        public IEnumerable<int> ExtractNumbers(IEnumerable<string> source)
        {
            int number = 0;

            foreach (string item in source)
            {
                if (int.TryParse(item, out number))
                {
                    yield return number;
                }
            }

            yield break;
        }

        /// <summary>
        /// Given two enumerables of strings, find the longest common word.
        /// 
        /// For example:
        /// 
        /// LongestCommonWord(
        ///     new List<string> {
        ///         "love",
        ///         "wandering",
        ///         "goofy",
        ///         "sweet",
        ///         "mean",
        ///         "show",
        ///         "fade",
        ///         "scissors",
        ///         "shoes",
        ///         "gainful",
        ///         "wind",
        ///         "warn"
        ///     },
        ///     new List<string> {
        ///         "wacky",
        ///         "fabulous",
        ///         "arm",
        ///         "rabbit",
        ///         "force",
        ///         "wandering",
        ///         "scissors",
        ///         "fair",
        ///         "homely",
        ///         "wiggly",
        ///         "thankful",
        ///         "ear"
        ///     }
        /// );
        /// 
        /// ; would return "wandering" as the longest common word.
        /// </summary>
        /// <param name="first">First list of words</param>
        /// <param name="second">Second list of words</param>
        /// <returns>longest common word between the two lists</returns>
        public string LongestCommonWord(IEnumerable<string> first, IEnumerable<string> second)
        {
            if (first.Count() == 0 || second.Count() == 0)
            {
                return string.Empty;
            }

            IEnumerable<string> commonItems = first.ToList()
                                              .ConvertAll(x => x.ToLower())
                                              .Intersect(second.ToList()
                                              .ConvertAll(y => y.ToLower()));

            if (commonItems.Count() > 0)
            {
                var length = commonItems.Max(s => s.Length);

                return commonItems.FirstOrDefault(s => s.Length == length);
            }
            else
            {
                return string.Empty;

            }
        }

        /// <summary>
        /// Write a method that converts kilometers to miles, given that there are
        /// 1.6 kilometers per mile.
        /// 
        /// For example:
        /// 
        /// DistanceInMiles(16.00);
        /// 
        /// ; would return 10.00;
        /// </summary>
        /// <param name="km">distance in kilometers</param>
        /// <returns></returns>
        public double DistanceInMiles(double km)
        {
            return km / Constants.KmMilesFactor;
        }

        /// <summary>
        /// Write a method that converts miles to kilometers, give that there are
        /// 1.6 kilometers per mile.
        /// 
        /// For example:
        /// 
        /// DistanceInKm(10.00);
        /// 
        /// ; would return 16.00;
        /// </summary>
        /// <param name="miles">distance in miles</param>
        /// <returns></returns>
        public double DistanceInKm(double miles)
        {
            return miles * Constants.KmMilesFactor;
        }

        /// <summary>
        /// Write a method that returns true if the word is a palindrome, false if
        /// it is not.
        /// 
        /// For example:
        /// 
        /// IsPalindrome("bolton");
        /// 
        /// ; would return false, and:
        /// 
        /// IsPalindrome("Anna");
        /// 
        /// ; would return true.
        /// 
        /// Also complete the related test case for this method.
        /// </summary>
        /// <param name="word">The word to check</param>
        /// <returns></returns>
        public bool IsPalindrome(string word)
        {            
            return Enumerable.Range(0, word.Length / 2)
                    .Select(i => char.ToLower(word[i]) == char.ToLower(word[word.Length - i - 1]))
                    .All(b => b);
        }

        /// <summary>
        /// Write a method that takes an enumerable list of objects and shuffles
        /// them into a different order.
        /// 
        /// For example:
        /// 
        /// Shuffle(new List<string>{ "one", "two" });
        /// 
        /// ; would return:
        /// 
        /// {
        ///   "two",
        ///   "one"
        /// }
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public IEnumerable<object> Shuffle(IEnumerable<object> source)
        {
            IEnumerable<object> target = ExtendedMethods.ShuffleExtender(source);

            while (Enumerable.SequenceEqual(source, target))
            {
                target = ExtendedMethods.ShuffleExtender(source);
            }

            return target;
        }



        /// <summary>
        /// Write a method that sorts an array of integers into ascending
        /// order - do not use any built in sorting mechanisms or frameworks.
        /// 
        /// Complete the test for this method.
        /// </summary>
        /// <param name="source">i.e. [1,3,4,2]</param>
        /// <returns>acsending sort [1,2,3,4]</returns>
        public int[] Sort(int[] source)
        {
            int temp;
            for (int i = 0; i < source.Length - 1; i++)
                for (int j = i + 1; j < source.Length; j++)
                    if (source[i] > source[j])
                    {
                        temp = source[i];
                        source[i] = source[j];
                        source[j] = temp;
                    }
            return source;
        }

        /// <summary>
        /// Each new term in the Fibonacci sequence is generated by adding the 
        /// previous two terms. By starting with 1 and 2, the first 10 terms will be:
        ///
        /// 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...
        ///
        /// By considering the terms in the Fibonacci sequence whose values do 
        /// not exceed four million, find the sum of the even-valued terms.
        /// </summary>
        /// <returns>4613732 </returns>
        public int FibonacciSum()
        {
            long limit = Constants.LimitForFibonacci;
            long even1 = 0, even2 = 2;
            long sum = even1 + even2;

            while (sum <= limit)
            {
                long even3 = 4 * even2 + even1;

                if (even3 > limit)
                    break;

                even1 = even2;
                even2 = even3;
                sum += even2;
            }

            return (int)sum;
        }

        /// <summary>
        /// Generate a list of integers from 1 to 100.
        /// 
        /// This method is currently broken, fix it so that the tests pass.
        /// </summary>
        /// <returns>list from 1 to 100</returns>
        public IEnumerable<int> GenerateList()
        {
            var ret = new List<int>();
            var numThreads = 2;
            object locker = new object();

            Thread[] threads = new Thread[numThreads];
            for (var i = 0; i < numThreads; i++)
            {
                threads[i] = new Thread(() =>
                {
                    var complete = false;
                    while (!complete)
                    {
                        lock (locker)
                        {
                            var next = ret.Count + 1;
                            Thread.Sleep(new Random().Next(1, 10));
                            if (next <= 100)
                            {
                                ret.Add(next);
                            }

                            if (ret.Count >= 100)
                            {
                                complete = true;
                            }
                        }
                    }
                });
                threads[i].Start();
            }

            for (var i = 0; i < numThreads; i++)
            {
                threads[i].Join();
            }

            return ret;
        }
    }
}
