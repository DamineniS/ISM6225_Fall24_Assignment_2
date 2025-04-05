using System;
using System.Collections.Generic;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Question 1: Find Missing Numbers in Array
            Console.WriteLine("Question 1:");
            int[] nums1 = [4,3,2,7,8,2,3,1]; // Example input
            // { 1,1,1,2,2,2,3,3,3,4,5,12};
            // {1,1}
            IList<int> missingNumbers = FindMissingNumbers(nums1);
            Console.WriteLine(string.Join(",", missingNumbers));

            // Question 2: Sort Array by Parity
            Console.WriteLine("Question 2:");
            int[] nums2 = { 3, 1, 2, 4 };//{1,1,2};//[6,5,3,4,2,1]; 
            int[] sortedArray = SortArrayByParity(nums2);
            Console.WriteLine(string.Join(",", sortedArray));

            // Question 3: Two Sum
            Console.WriteLine("Question 3:");
            int[] nums3 = //{9,7,11,15}; //if the target itself is a number in the array 
            // {11,12,3,4,5,6,7,7,6,5,4,5,3,534,534,53}; //if there are huge and multiple number
             { 2, 7, 11, 15 };
            int target = 9;
            int[] indices = TwoSum(nums3, target);
            Console.WriteLine(string.Join(",", indices));

            // Question 4: Find Maximum Product of Three Numbers
            Console.WriteLine("Question 4:");
            int[] nums4 = //{-6,-5,-4,5,6,7}; //the case works for negetive numbers and if the product is equal
            {1, 2, 3, 4 };
            int maxProduct = MaximumProduct(nums4);
            Console.WriteLine(maxProduct);

            // Question 5: Decimal to Binary Conversion
            Console.WriteLine("Question 5:");
            int decimalNumber = 42;
            //-42;in case a negative number is passed, absolute value is taken
            string binary = DecimalToBinary(decimalNumber);
            Console.WriteLine(binary);

            // Question 6: Find Minimum in Rotated Sorted Array
            Console.WriteLine("Question 6:");
            int[] nums5 = {-10,-8,0,1,2,3}; //in case a negative number is passed
            //{ 3, 4, 5, 1, 2 };
            int minElement = FindMin(nums5);
            Console.WriteLine(minElement);

            // Question 7: Palindrome Number
            Console.WriteLine("Question 7:");
            int palindromeNumber = -121; //if a negative number is passed, we take the absolute value
            //121;
            bool isPalindrome = IsPalindrome(palindromeNumber);
            Console.WriteLine(isPalindrome);

            // Question 8: Fibonacci Number
            Console.WriteLine("Question 8:");
            int n = -4;
            int fibonacciNumber = Fibonacci(n);
            Console.WriteLine(fibonacciNumber);
        }

        // Question 1: Find Missing Numbers in Array
        public static IList<int> FindMissingNumbers(int[] nums)
        {
            try
            {
                int nums_length = nums.Length;
                IList<int> missing_nums = new List<int>();
                //Given that the length of the array and the maximum number in the array will be the same
                // The following approach will work for any n numbers
                // we can loop through the array and identify the indexes that have the missing numbers
                // we can do this by eleminating the indexes that have right numbers if sorted
                for (int i = 0; i < nums_length; i++)
                {
                    int actual = Math.Abs(nums[i]) - 1; // Calculate the absolute value of the number
                    if (nums[actual] > 0) // If the number is greater than 0
                    {
                        nums[actual] = -nums[actual]; // Make it negative
                    }
                }

                // Find missing numbers (those that are still positive)
                for (int i = 0; i < nums_length; i++)
                {
                    if (nums[i] > 0) // If the number is still positive
                    {
                        missing_nums.Add(i + 1); // Add the missing number to the list
                    }
                }

                return missing_nums; // Return the missing numbers
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 2: Sort Array by Parity
        public static int[] SortArrayByParity(int[] nums)
        {
            try
            {
                int nums_length = nums.Length;
                int l = 0;
                int r = nums_length - 1;
                Array.Sort(nums);
                while (l < r)
                {
                    if (nums[l] % 2 == 0) // If the number is even
                    {
                        l++; // Move to the next number
                    }
                    else if (nums[r] % 2 == 1) // If the number is odd
                    {
                        r--; // Move to the previous number
                    }
                    else // If the numbers are in the wrong order
                    {
                        int temp = nums[l]; // Swap them
                        nums[l] = nums[r];
                        nums[r] = temp;
                    }
                }
            

                return nums; // Return the sorted array
                
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 3: Two Sum
        public static int[] TwoSum(int[] nums, int target)
        {
            try
            {
                for(int i = 0; i < nums.Length; i++)
                {
                    if(nums[i] == target) //if the target itself is a number in the array
                    {
                        return new int[] { i }; // Return the index of the target number as an array
                    }
                    for (int j = i + 1; j < nums.Length; j++)
                    {
                        if (nums[i] + nums[j] == target) // Adding every number with the rest, to match the target
                        {
                            // If the sum of the two numbers equals the target
                            // Return the indices of the two numbers
                            return new int[] { i, j }; // Return the indices of the two numbers
                        }
                    }
                }
                return new int[] { }; // Return an empty array if no solution is found
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 4: Find Maximum Product of Three Numbers
        public static int MaximumProduct(int[] nums)
        {
            try
            {
                Array.Sort(nums); // Sort the array
                int n = nums.Length;
                // Calculate the maximum product of three numbers
                if (nums[2] < 0)
                {
                    // If there are negative numbers, we need to consider the product of two negative numbers and one positive number
                    return Math.Max(nums[n - 1] * nums[n - 2] * nums[n - 3], nums[0] * nums[1] * nums[2]);
                }
                else
                {
                    // If all numbers are positive or mixed, take the product of the last three numbers
                    return nums[n - 1] * nums[n - 2] * nums[n - 3];
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 5: Decimal to Binary Conversion
        public static string DecimalToBinary(int decimalNumber)
        {
            //code suggester by copilot
            try
            {
                //incase a negative number is passed
                if (decimalNumber < 0)
                {
                  decimalNumber = Math.Abs(decimalNumber); // Convert to positive
                }
                string binary = string.Empty;
                while (decimalNumber > 0)
                {
                    binary = (decimalNumber % 2) + binary; // Prepend the remainder to the binary string
                    decimalNumber /= 2; // Divide the number by 2
                }
                return binary; // Return the binary representation
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 6: Find Minimum in Rotated Sorted Array
        public static int FindMin(int[] nums)
        {
            try
            {
                Array.Sort(nums); // Sort the array
                int n = nums.Length;
                // The minimum element will be the first element after sorting
                return nums[0]; // Return the minimum element
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 7: Palindrome Number
        public static bool IsPalindrome(int x)
        {
            try
            {
                x = Math.Abs(x); // Convert to positive
                int l= 0;
                int temp = x; // Convert to positive
                int reversed = 0;
                while (temp > 0)
                {
                    l = temp % 10; // Get the last digit
                    reversed = reversed * 10 + l; // Build the reversed number
                    temp /= 10; // Remove the last digit
                }
                // Check if the original number is equal to the reversed number
                if (x == reversed)
                {
                    return true; // The number is a palindrome
                }
                else
                {
                    return false; // The number is not a palindrome
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 8: Fibonacci Number
        public static int Fibonacci(int n)
        {
            try
            {
                if (n < 0 || n > 30)
                {
                    throw new ArgumentOutOfRangeException(nameof(n), "Input must be between 0 and 30."); 
                }
                n = Math.Abs(n); // Convert to positive 
                if (n == 0) return 0; // handling base case
                if (n == 1) return 1; // handling base case
                int a = 0, b = 1, c = 0;
                for (int i = 2; i <= n; i++)
                {
                    c = a + b; // Calculate the next Fibonacci number
                    a = b; // Update a
                    b = c; // Update b
                }
                return c; // Return the nth Fibonacci number

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
