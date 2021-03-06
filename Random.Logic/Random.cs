﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Random.Logic
{
    public class Random
    {
        public int[] TwoSum(int[] nums, int target)
        {
            var dicOfArrayItems = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];

                if (dicOfArrayItems.ContainsKey(complement))
                {
                    return new int[] { dicOfArrayItems[complement], i };
                }

                if (!dicOfArrayItems.ContainsKey(nums[i]))
                {
                    dicOfArrayItems.Add(nums[i], i);
                }
            }

            throw new ArgumentException();
        }

        public int LengthOfLongestSubstring(string s)
        {
            var listOfLengthOfWindows = new List<int>();

            char[] chars = s.ToCharArray();

            var dictionaryOfArrays = new Dictionary<char, int>();

            int maxLength = 0;
            int lengthOfMovingWindow = 0;
            int count = 0;
            foreach (char ch in chars)
            {
                if (dictionaryOfArrays.ContainsKey(ch))
                {
                    var beginningOfLength = dictionaryOfArrays[ch];
                    lengthOfMovingWindow = count - beginningOfLength;

                    dictionaryOfArrays.Remove(ch);

                    if (lengthOfMovingWindow > maxLength)
                        maxLength = lengthOfMovingWindow;

                    lengthOfMovingWindow = 0;
                }
                else
                {
                    lengthOfMovingWindow++;
                }

                dictionaryOfArrays[ch] = count;
                count++;
            }

            if (count > 0 && maxLength == 0)
            {
                return count;
            }

            return maxLength;
        }

        public int MaxArea(int[] height)
        {
            int maxarea = 0, l = 0, r = height.Length - 1;

            while (l < r)
            {
                maxarea = Math.Max(maxarea, Math.Min(height[l], height[r]) * (r - l));
                if (height[l] < height[r])
                    l++;
                else
                    r--;
            }
            return maxarea;
        }

        public string IntToRoman(int num)
        {
            String[] thousands = { "", "M", "MM", "MMM" };
            String[] hundreds = { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };
            String[] tens = { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
            String[] ones = { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };

            return thousands[num / 1000] + hundreds[num % 1000 / 100] + tens[num % 100 / 10] + ones[num % 10];
        }

        private string romanString => string.Empty;

        public int RomanToInt(string s)
        {
            var values = new Dictionary<string, int>()
            {
                {"M", 1000},
                {"D", 500},
                {"C", 100},
                {"L", 50},
                {"X", 10},
                {"V", 5}
            };

            int sum = 0;

            int i = 0;
            while (i < s.Length)
            {
                String currentSymbol = s.Substring(i, i + 1);
                int currentValue = values[currentSymbol];
                int nextValue = 0;
                if (i + 1 < s.Length)
                {
                    String nextSymbol = s.Substring(i + 1, i + 2);
                    nextValue = values[nextSymbol];
                }

                if (currentValue < nextValue)
                {
                    sum += (nextValue - currentValue);
                    i += 2;
                }
                else
                {
                    sum += currentValue;
                    i += 1;
                }
            }
            return sum;
        }

        public int StrStr(string haystack, string needle)
        {
            if (string.IsNullOrWhiteSpace(needle))
                return 0;

            var movingWindowLength = needle.Length;

            if (movingWindowLength > haystack.Length)
                return -1;

            for (int index = 0; index <= haystack.Length - movingWindowLength; index++)
            {
                var currentStr = haystack.Substring(index, movingWindowLength);

                if (currentStr == needle)
                    return index;
            }

            return -1;
        }

        public void Rotate(int[][] matrix)
        {
            int n = matrix.Length;

            // transpose matrix
            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n; j++)
                {
                    int tmp = matrix[j][i];
                    matrix[j][i] = matrix[i][j];
                    matrix[i][j] = tmp;
                }
            }
            // reverse each row
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n / 2; j++)
                {
                    int tmp = matrix[i][j];
                    matrix[i][j] = matrix[i][n - j - 1];
                    matrix[i][n - j - 1] = tmp;
                }
            }
        }

        public IList<int> SpiralOrder()
        {
            var matrix = new int[3][];
            matrix[0] = new[] { 1, 2, 3, 4 };
            matrix[1] = new[] { 5, 6, 7, 8 };
            matrix[2] = new[] { 9, 10, 11, 12 };

            var output = new List<int>();

            var r1 = 0;
            var r2 = matrix.Length - 1;

            var c1 = 0;
            var c2 = matrix[0].Length - 1;

            while (r1 <= r2 && c1 <= c2)
            {
                // top row
                for (int c = c1; c <= c2; c++) output.Add(matrix[r1][c]);

                // last Column
                for (int r = r1 + 1; r <= r2; r++) output.Add(matrix[r][c2]);

                if (r1 < r2 && c1 < c2)
                {
                    for (int c = c2 - 1; c > c1; c--) output.Add(matrix[r2][c]);
                    for (int r = r2; r > r1; r--) output.Add(matrix[r][c1]);
                }
                
                r1++;
                r2--;
                c2--;
                c1++;
            }

            return output;
        }

        public void SetZeroes(int[][] matrix)
        {
            var rows = new HashSet<int>();
            var columns = new HashSet<int>();

            int m = matrix.Length;
            int n = matrix[0].Length;

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        rows.Add(i);
                        columns.Add(j);
                    }
                }
            }

            for (int ii = 0; ii < m; ii++)
            {
                for (int jj = 0; jj < n; jj++)
                {
                    if (rows.Contains(ii))
                    {
                        matrix[ii][jj] = 0;
                    }

                    if (columns.Contains(jj))
                    {
                        matrix[ii][jj] = 0;
                    }
                }
            }
        }

        public int NumTeams(int[] rating)
        {
            var output = 0;

            for (int i = 0; i < rating.Length; i++)
            {
                var head = rating[i];

                for (int j = i + 1; j < rating.Length; j++)
                {
                    var middle = rating[j];

                    for (int k = j + 1; k < rating.Length; k++)
                    {
                        var tail = rating[k];
                        if (head < middle && middle < tail)
                        {
                            output++;
                        }
                        else if (head > middle && middle > tail)
                        {
                            output++;
                        }
                    }
                }
            }

            return output;
        }

        public int CompareVersion(string version1, string version2)
        {
            var version1Revisions = version1.Split('.').ToList();
            var version2Revisions = version2.Split('.').ToList();

            var maxLength = Math.Max(version1Revisions.Count, version2Revisions.Count);

            if (version1Revisions.Count < version2Revisions.Count)
            {
                NormalizeList(version1Revisions, version2Revisions.Count - version1Revisions.Count);
            }
            else if (version1Revisions.Count > version2Revisions.Count)
            {
                NormalizeList(version2Revisions, version1Revisions.Count - version2Revisions.Count);
            }

            for (int i = 0; i < maxLength; i++)
            {
                var version1Revision = version1Revisions[i];
                var version2Revision = version2Revisions[i];

                if (int.Parse(version1Revision) > int.Parse(version2Revision))
                {
                    return 1;
                }
                else if (int.Parse(version1Revision) < int.Parse(version2Revision))
                {
                    return -1;
                }
            }

            return 0;
        }

        private List<string> NormalizeList(List<string> input, int countOrElements)
        {
            for (int i = 0; i < countOrElements; i++)
            {
                input.Add("0");
            }

            return input;
        }

        public string NumberToWordsHelper(int num)
        {
            if (num == 0)
            {
                return "zero";
            }

            var singleDigits = new string[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var tens = new string[] { "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
            var Overs = new string[] { "thousand", "million", "billion" };

            var modWithHundred = num / 100;
            var remainderWithHundred = num % 100;

            var output = string.Empty;
            if (modWithHundred > 0)
            {
                output = $"{singleDigits[modWithHundred]} hundred";
            }

            if (remainderWithHundred > 0)
            {
                var modWithTens = remainderWithHundred / 10;
                var remainderWithTens = remainderWithHundred % 10;

                if (modWithTens > 0)
                {
                    output = $"{output} {tens[modWithTens - 1]}";
                }

                if (remainderWithTens > 0)
                {
                    output = $"{output} {singleDigits[remainderWithTens]}";
                }
            }

            return output.Trim(' ');
        }

        public int FibonacciDynamicPro(int[] memoization, int n)
        {
            if (memoization.Contains(n))
            {
                return memoization[n];
            }

            if (n == 0)
            {
                memoization[n] = 0;
                return 0;
            }

            if (n == 1)
            {
                memoization[n] = 0;
                return 0;
            }

            if (n == 2)
            {
                memoization[n] = 1;
                return 1;
            }

            memoization[n] = FibonacciDynamicPro(memoization, n - 1) + FibonacciDynamicPro(memoization, n - 2);
            return memoization[n];
        }

        public int[] CellCompete(int[] states, int days)
        {
            if (states == null)
                return null;

            if (days == 0)
                return states;

            if (states.Length == 1)
            {
                return states;
            }

            var previousState = 0;
            var tempState = 0;

            for (int j = 1; j <= days; j++)
            {
                for (int i = 0; i < states.Length; i++)
                {
                    tempState = states[i];
                    if (i == 0)
                    {
                        states[i] = GetNewValue(0, states[i], states[i + 1]);
                    }
                    else if (i == states.Length - 1)
                    {
                        previousState =
                        states[i] = GetNewValue(previousState, states[i], 0);
                    }
                    else
                    {
                        states[i] = GetNewValue(previousState, states[i], states[i + 1]);
                    }
                    previousState = tempState;
                }
            }

            return states;
        }

        private int GetNewValue(int left, int node, int right)
        {
            if ((left == 0 && right == 0) || (left == 1 && right == 1))
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public int generalizedGCD(int num, int[] arr)
        {
            // WRITE YOUR CODE HERE

            int result = arr[0];

            for (int i = 0; i < num; i++)
            {
                result = gcd(arr[i], result);

                if (result == 0)
                {
                    return 1;
                }
            }

            return result;
        }

        private static int gcd(int a, int b)
        {
            if (a == 0)
                return b;

            return gcd(b % a, a);
        }

        private const int MaxNumberOfInstance = 100000000;

        public int finalInstances(int instances, List<int> averageUtil)
        {
            var sizeOfAverageUtil = averageUtil.Count;

            for (int i = 0; i < sizeOfAverageUtil; i++)
            {
                if (averageUtil[i] < 25 && instances > 1)
                {
                    instances = instances / 2 + (instances % 2 > 0 ? 1 : 0);
                    i += 10;
                    continue;
                }
                else if (averageUtil[i] > 60)
                {
                    var tempInstances = instances * 2;

                    if (tempInstances < MaxNumberOfInstance)
                    {
                        instances = tempInstances;
                        i += 10;
                    }
                }
            }

            return instances;
        }

        public List<int> numberOfItems(string s, List<int> startIndices, List<int> endIndices)
        {
            var dictOfPipes = new Dictionary<int, int>();

            var numbersOfItems = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '|')
                {
                    dictOfPipes[i] = numbersOfItems;
                }
                else
                {
                    numbersOfItems++;
                }
            }

            var output = new List<int>();

            for (int j = 0; j < startIndices.Count; j++)
            {
                var value = GetItemHelper(dictOfPipes, startIndices[j] - 1, endIndices[j] - 1);
                output.Add(value);
            }

            return output;
        }

        //public static List<int> numberOfItems(string s, List<int> startIndices, List<int> endIndices)
        //{
        //    //
        //    var dictOfPipes = new Dictionary<int, int>();

        //    var numbersOfItems = 0;
        //    for (int i = 0; i < s.Length; i++)
        //    {
        //        if (s[i] == '|')
        //        {
        //            dictOfPipes[i] = numbersOfItems;
        //        }
        //        else
        //        {
        //            numbersOfItems++;
        //        }
        //    }

        //    var output = new List<int>();

        //    for (int j = 0; j < startIndices.Count; j++)
        //    {
        //        var value = GetItemHelper(dictOfPipes, startIndices[j] - 1, endIndices[j] - 1);
        //        output.Add(value);
        //    }

        //    return output;

        //}

        private static int GetItemHelper(Dictionary<int, int> dict, int startIndex, int endIndex)
        {
            var numberOfItems = 0;

            if (dict.Keys.Max() >= endIndex)
            {
                int countSofar = 0;
                for (int i = startIndex; i < endIndex; i++)
                {
                    if (dict.ContainsKey(i))
                    {
                        numberOfItems += dict[i] - countSofar;
                        countSofar = dict[i];
                    }
                }
            }
            return numberOfItems;
        }

        public int GetMaxPairwiseProduct(int[] numbers)
        {
            int maxProduct = 0;
            int n = numbers.Length;

            for (int first = 0; first < n; ++first)
            {
                for (int second = first + 1; second < n; ++second)
                {
                    maxProduct = Math.Max(maxProduct,
                        numbers[first] * numbers[second]);
                }
            }

            return maxProduct;
        }

        public (long, string) GetMaxPairwiseProductFast(int[] numbers)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            long n = numbers.Length;

            var index1 = 1;
            for (long i = 2; i < n; ++i)
            {
                if (numbers[i] > numbers[index1])
                {
                    index1 = (int)i;
                }
            }

            var index2 = 1;
            for (long i = 2; i < n; ++i)
            {
                if (numbers[i] > numbers[index2] && numbers[i] != numbers[index1])
                {
                    index2 = (int)i;
                }
            }

            var product = numbers[index1] * numbers[index2];

            stopWatch.Stop();

            TimeSpan ts = stopWatch.Elapsed;
            return (product, ts.ToString());
        }

        public (long, string) GetMaxPairwiseProductCompact(int[] numbers)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            long n = numbers.Length;

            Array.Sort(numbers);

            // Quick_Sort(numbers, 0, numbers.Length - 1);

            var product = numbers[numbers.Length - 1] * numbers[numbers.Length - 2];

            stopWatch.Stop();

            TimeSpan ts = stopWatch.Elapsed;
            return (product, ts.ToString());
        }

        private static void Quick_Sort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(arr, left, right);

                if (pivot > 1)
                {
                    Quick_Sort(arr, left, pivot - 1);
                }
                if (pivot + 1 < right)
                {
                    Quick_Sort(arr, pivot + 1, right);
                }
            }
        }

        private static int Partition(int[] arr, int left, int right)
        {
            int pivot = arr[left];
            while (true)
            {
                while (arr[left] < pivot)
                {
                    left++;
                }

                while (arr[right] > pivot)
                {
                    right--;
                }

                if (left < right)
                {
                    if (arr[left] == arr[right]) return right;

                    int temp = arr[left];
                    arr[left] = arr[right];
                    arr[right] = temp;
                }
                else
                {
                    return right;
                }
            }
        }

        public string RemoveKDigits(string num, int k)
        {
            if (k >= num.Length)
                return "0";

            var toIndex = k;
            var fromIndex = 0;

            var output = string.Empty;
            for (int i = 0; i < k; i++)
            {
                var minimumIndex = FindMinimum(num.Substring(fromIndex, toIndex));

                output += num[fromIndex + minimumIndex].ToString();
            }

            //var outPut = $"{minimumInt}{remainingString}";
            //return outPut.All(c => c == "0") ? ;
            return output;
        }

        private int FindMinimum(string stringToParse)
        {
            var minimumInt = int.Parse(stringToParse[0].ToString());
            var index = 0;
            for (var i = 0; i < stringToParse.Length; i++)
            {
                var t = stringToParse[i];
                var numInt = int.Parse(t.ToString());
                if (numInt < minimumInt)
                {
                    minimumInt = numInt;
                    index = i;
                }
            }

            return index;
        }

        public bool IsPalindrome(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return true;

            var length = s.Length;
            if (length == 1)
                return true;

            int j = length - 1;
            int i = 0;
            while (true)
            {
                if (i > length - 1 || j < 0)
                    return true;

                if (!char.IsLetterOrDigit(s[i]))
                {
                    i++;
                    continue;
                }

                if (!char.IsLetterOrDigit(s[j]))
                {
                    j--;
                    continue;
                }

                if (i >= j)
                    break;

                var head = s[i].ToString();
                var tail = s[j].ToString();

                if (!String.Equals(head, tail, StringComparison.OrdinalIgnoreCase))
                    return false;
                i++;
                j--;
            }

            return true;
        }

        public void ReverseString(char[] s)
        {
            var length = s.Length;
            if (length == 1)
                return;

            int j = length - 1;

            for (int i = 0; i < length / 2; i++)
            {
                var temp = s[i];
                s[i] = s[j];
                s[j] = temp;

                j--;
            }
        }

        public string ReverseWords(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return s;

            var length = s.Length;
            if (length == 1)
                return s;

            int tailStartIndx = length - 1;
            int tailEndIndx = length - 1;
            bool didFindAWordInTail = false;

            int headStartIndx = 0;
            int headendIndx = 0;
            bool didFindAWordInHead = false;

            while (true)
            {
                if (char.IsWhiteSpace(s[headStartIndx]))
                {
                    headStartIndx++;
                    continue;
                }

                if (char.IsWhiteSpace(s[tailStartIndx]))
                {
                    tailStartIndx--;
                    continue;
                }

                if (char.IsWhiteSpace(s[headendIndx]))
                {
                    headendIndx++;
                    continue;
                }

                if (!char.IsWhiteSpace(s[tailEndIndx]))
                {
                    tailEndIndx--;
                    continue;
                }

                var headWord = s.Substring(headStartIndx, headendIndx - headStartIndx);
                var tailWord = s.Substring(tailEndIndx + 1, tailStartIndx - tailEndIndx);

                break;
            }

            return string.Empty;
        }

        public int MyAtoi(string s)
        {
            if (s.Length == 0)
                return 0;

            var allowableChars = new char[] { '-', '+' };

            var isPositive = true;
            var sigangeHasBeenDetected = false;
            var output = 0;

            foreach (var t in s)
            {
                if (char.IsWhiteSpace(t))
                {
                    continue;
                }

                if (!char.IsNumber(t))
                {
                    if (!allowableChars.Contains(t))
                    {
                        return output;
                    }
                }

                if (t == '-' && !sigangeHasBeenDetected)
                {
                    isPositive = false;
                    sigangeHasBeenDetected = true;
                }
                else if (t == '+' && !sigangeHasBeenDetected)
                {
                    isPositive = true;
                    sigangeHasBeenDetected = true;
                }
                else
                {
                    if (output >= int.MaxValue / 10)
                    {
                        output = int.MaxValue;
                        break;
                    }
                    else
                    {
                        output = output * 10 + int.Parse(t.ToString());
                    }
                }
            }

            return isPositive ? output : -1 * output;
        }

        public bool IsValid(string s)
        {
            if (s.Length == 0)
                return false;

            var stackOfItems = new Stack<char>();

            foreach (var item in s)
            {
                switch (item)
                {
                    case ')':
                        if (stackOfItems.Count > 0 && stackOfItems.Peek() == '(')
                        {
                            stackOfItems.Pop();
                        }
                        else
                        {
                            stackOfItems.Push(item);
                        }
                        break;

                    case ']':
                        if (stackOfItems.Count > 0 && stackOfItems.Peek() == '[')
                        {
                            stackOfItems.Pop();
                        }
                        else
                        {
                            stackOfItems.Push(item);
                        }
                        break;

                    case '}':
                        if (stackOfItems.Count > 0 && stackOfItems.Peek() == '{')
                        {
                            stackOfItems.Pop();
                        }
                        else
                        {
                            stackOfItems.Push(item);
                        }
                        break;

                    default:
                        stackOfItems.Push(item);
                        break;
                }
            }

            return stackOfItems.Count == 0;
        }

        public String longestPalindrome(String s)
        {
            if (string.IsNullOrEmpty(s)) return "";

            int start = 0, end = 0;

            for (int i = 0; i < s.Length; i++)
            {
                int len1 = expandAroundCenter(s, i, i);
                int len2 = expandAroundCenter(s, i, i + 1);
                int len = Math.Max(len1, len2);
                if (len > end - start)
                {
                    start = i - (len - 1) / 2;
                    end = i + len / 2;
                }
            }
            return s.Substring(start, end + 1);
        }

        private int expandAroundCenter(string s, int left, int right)
        {
            int l = left, r = right;
            while (l >= 0 && r < s.Length && s[l] == s[r])
            {
                l--;
                r++;
            }
            return r - l - 1;
        }

        public IList<IList<String>> GroupAnagrams(String[] strs)
        {
            if (strs.Length == 0) return new List<IList<string>>();

            var ans = new Dictionary<string, List<string>>();

            foreach (var str in strs)
            {
                char[] ca = str.ToCharArray();
                Array.Sort(ca);

                var key = new string(ca);

                if (!ans.ContainsKey(key))
                    ans.Add(key, new List<string>());

                ans[key].Add(str);
            }

            return ans.Select(_ => _.Value).ToArray();
        }

        public int Trap(int[] height)
        {
            if (height == null)
                return 0;
            int ans = 0;
            int size = height.Length;

            var leftMax = new int[size];
            var rightMax = new int[size];

            leftMax[0] = height[0];
            for (int i = 1; i < size; i++)
            {
                leftMax[i] = Math.Max(height[i], leftMax[i - 1]);
            }
            rightMax[size - 1] = height[size - 1];
            for (int i = size - 2; i >= 0; i--)
            {
                rightMax[i] = Math.Max(height[i], rightMax[i + 1]);
            }
            for (int i = 1; i < size - 1; i++)
            {
                ans += Math.Min(leftMax[i], rightMax[i]) - height[i];
            }
            return ans;
        }

        public int TrapStack(int[] height)
        {
            int ans = 0, current = 0;
            var st = new Stack<int>();

            while (current < height.Length)
            {
                while (st.Count > 0 && height[current] > height[st.Peek()])
                {
                    int top = st.Peek();
                    st.Pop();
                    if (st.Count == 0)
                        break;
                    int distance = current - st.Peek() - 1;
                    int boundedHeight = Math.Min(height[current], height[st.Peek()]) - height[top];
                    ans += distance * boundedHeight;
                }
                st.Push(current++);
            }
            return ans;
        }
    }
}