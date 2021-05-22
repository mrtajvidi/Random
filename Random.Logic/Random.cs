using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

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

        public int FibonacciDynamicProgrammingTopBottom(int[] memoization, int n)
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

            memoization[n] = FibonacciDynamicProgrammingTopBottom(memoization, n - 1) + FibonacciDynamicProgrammingTopBottom(memoization, n - 2);
            return memoization[n];
        }

        public int FibonacciDynamicProgrammingBottomUp(int n)
        {
            var memoize = new int[n];

            memoize[0] = 0;
            memoize[1] = 1;

            for (int i = 3; i <= n; i++)
            {
                memoize[i] = memoize[i - 1] + memoize[i - 2];
            }

            return memoize[n];
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

        public int MinDeletions(string s)
        {
            var dict = new Dictionary<char, int>();

            foreach (var ch in s)
            {
                if (dict.ContainsKey(ch))
                {
                    dict[ch]++;
                }
                else
                {
                    dict[ch] = 1;
                }
            }
            var setOfOccurance = new HashSet<int>();
            var countOfRemoval = 0;
            foreach (var item in dict.Values)
            {
                var valueToBeAdded = item;
                do
                {
                    if (!setOfOccurance.Contains(valueToBeAdded))
                    {
                        setOfOccurance.Add(valueToBeAdded);
                        break;
                    }
                    else
                    {
                        countOfRemoval++;
                        valueToBeAdded--;
                    }
                } while (valueToBeAdded > 0);
            }
            return countOfRemoval;
        }

        public int FindMinimumSwapsToMakePalindrome(string s)
        {
            var output = 0;
            var stringArray = s.ToCharArray();

            var headIndex = 0;
            var tailIndex = s.Length - 1;

            foreach (var ch in stringArray)
            {
                if (headIndex >= tailIndex)
                {
                    return output;
                }

                if (s[headIndex] == s[tailIndex])
                {
                    headIndex++;
                    tailIndex--;
                    continue;
                }
                else
                {
                    bool foundMatch = false;
                    for (int j = tailIndex - 1; j > headIndex; j--)
                    {
                        if (s[j] == s[headIndex])
                        {
                            Swap(stringArray, tailIndex, j);
                            output += 2 * (tailIndex - j - 1) + 1;
                            foundMatch = true;
                            break;
                        }
                    }

                    if (!foundMatch)
                        return -1;

                    headIndex++;
                    tailIndex--;
                }
            }

            return output;
        }

        private void Swap(char[] inputArray, int firstIndex, int secondIndex)
        {
            var temp = inputArray[firstIndex];
            inputArray[firstIndex] = inputArray[secondIndex];
            inputArray[secondIndex] = temp;
        }

        public List<int> MergeSort(List<int> unsorted)
        {
            if (unsorted.Count <= 1)
                return unsorted;

            var middle = unsorted.Count / 2;
            List<int> left = new List<int>();
            List<int> right = new List<int>();

            for (int i = 0; i < middle; i++)
            {
                left.Add(unsorted[i]);
            }
            for (int i = middle; i < unsorted.Count; i++)
            {
                right.Add(unsorted[i]);
            }

            left = MergeSort(left);
            right = MergeSort(right);

            return Merge(left, right);
        }

        private List<int> Merge(List<int> leftList, List<int> rightList)
        {
            List<int> result = new List<int>();

            while (leftList.Count > 0 || rightList.Count > 0)
            {
                if (leftList.Count > 0 && rightList.Count > 0)
                {
                    var left = leftList.First();
                    var right = rightList.First();
                    if (left <= right)
                    {
                        result.Add(left);
                        leftList.Remove(left);
                    }
                    else
                    {
                        result.Add(right);
                        rightList.Remove(right);
                    }
                }
                else if (leftList.Count > 0)
                {
                    var left = leftList.First();
                    result.Add(left);
                    leftList.Remove(left);
                }
                else if (rightList.Count > 0)
                {
                    var right = rightList.First();
                    result.Add(right);
                    rightList.Remove(right);
                }
            }

            return result;
        }

        public bool AreTheyEqual(int[] arr_a, int[] arr_b)
        {
            Array.Sort(arr_a);
            Array.Sort(arr_b);

            for (int i = 0; i < arr_a.Length; i++)
            {
                if (arr_a[i] != arr_b[i])
                {
                    return false;
                }
            }
            return true;
        }

        public string RotationalCipher(String input, int rotationFactor)
        {
            // Write your code here
            var digitRotationCipher = rotationFactor % 10;
            var alphabetRotationCipher = rotationFactor % 26;

            var alphabets = new char[]
            {
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U',
                'V', 'W', 'X', 'Y', 'Z'
            };
            var digits = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            var output = new StringBuilder();

            foreach (var item in input)
            {
                if (Char.IsDigit(item))
                {
                    var mod = (int.Parse(item.ToString()) + digitRotationCipher) % 10;
                    output.Append(mod.ToString());
                }
                else if (Char.IsLetter(item))
                {
                    var isLower = Char.IsLower(item);
                    var characterToFind = isLower ? Char.ToUpper(item) : item;

                    var mod = (Array.IndexOf(alphabets, characterToFind) + alphabetRotationCipher) % 26;
                    output.Append(isLower ? Char.ToLower(alphabets[mod]) : Char.ToUpper(alphabets[mod]));
                }
                else
                {
                    output.Append(item);
                }
            }

            return output.ToString();
        }

        public int GetTotalTime(int[] arr)
        {
            Array.Sort(arr);
            int sum = arr[arr.Length - 1];
            int penalty = 0;
            for (int i = arr.Length - 2; i >= 0; i--)
            {
                sum += arr[i];
                penalty += sum;
            }
            return penalty;
        }

        public bool IsBalanced(string s)
        {
            var stack = new Stack<char>();

            var endCharacters = new char[] { ']', '}', ')' };

            foreach (var ch in s)
            {
                if (endCharacters.Contains(ch))
                {
                    var nextItem = stack.Peek();
                    if (nextItem == null)
                    {
                        return false;
                    }
                    else if (ch == ')' && nextItem == '(')
                    {
                        stack.Pop();
                    }
                    else if (ch == ']' && nextItem == '[')
                    {
                        stack.Pop();
                    }
                    else if (ch == '}' && nextItem == '{')
                    {
                        stack.Pop();
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    stack.Push(ch);
                }
            }

            return true;
        }

        public string FindEncryptedWordHelper(string s)
        {
            if (s.Length <= 2)
            {
                return s;
            }

            var sizeOfHalfOfString = s.Length / 2;
            var midCharacterIndex = (sizeOfHalfOfString % 2 == 0) ? sizeOfHalfOfString - 1 : sizeOfHalfOfString;

            var leftSubstring = s.Substring(0, midCharacterIndex);
            var rightSubstring = s.Substring(midCharacterIndex + 1, s.Length - (midCharacterIndex + 1));

            return s[midCharacterIndex] + FindEncryptedWordHelper(leftSubstring)
                                        + FindEncryptedWordHelper(rightSubstring);
        }

        public bool BalancedSplitExists(int[] arr)
        {
            Array.Sort(arr);

            if (arr.Length < 2) return false;

            var forwardDictionary = new Dictionary<int, int>();
            var backwardDictionary = new Dictionary<int, int>();

            int cummulativeSum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                forwardDictionary[i] = arr[i] + cummulativeSum;
                cummulativeSum = forwardDictionary[i];
            }

            cummulativeSum = 0;
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                backwardDictionary[i] = arr[i] + cummulativeSum;
                cummulativeSum = backwardDictionary[i];
            }

            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (backwardDictionary[i + 1] == forwardDictionary[i] && arr[i] != arr[i + 1])
                {
                    return true;
                }
            }
            return false;
        }

        public int BinarySearch(int[] nums, int target)
        {
            var output = BinarySearchHelper(nums, 0, nums.Length - 1, target);
            return output;
        }

        private int BinarySearchHelper(int[] sums, int startIndex, int endIndex, int target)
        {
            if (startIndex > endIndex)
            {
                return -1;
            }

            int midIndex = (endIndex + startIndex) / 2;

            if (sums[midIndex] == target)
            {
                return midIndex;
            }
            else if (target < sums[midIndex])
            {
                return BinarySearchHelper(sums, startIndex, midIndex - 1, target);
            }
            else
            {
                return BinarySearchHelper(sums, midIndex + 1, endIndex, target);
            }
        }

        public int MySqrt(int x)
        {
            if (x < 2)
            {
                return x;
            }

            int start = 2;
            int end = x / 2;

            while (start <= end)
            {
                var pivot = start + (end - start) / 2;
                var sqrt = (long)pivot * pivot;

                if (sqrt > x)
                {
                    end = pivot - 1;
                }
                else if (sqrt < x)
                {
                    start = pivot + 1;
                }
                else
                {
                    return pivot;
                }
            }

            return end;
        }

        private int myGuess;

        public void InitialGuess(int guess)
        {
            myGuess = guess;
        }

        public int GuessNumber(int n)
        {
            var start = 1;
            var end = n;

            while (start <= end)
            {
                var mid = start + (end - start) / 2;
                var guessResult = Guess(mid);
                if (guessResult == 0)
                {
                    return mid;
                }
                else if (guessResult == 1)
                {
                    end = mid - 1;
                }
                else
                {
                    start = mid + 1;
                }
            }

            return -1;
        }

        private int Guess(int mid)
        {
            if (mid < myGuess)
            {
                return -1;
            }
            else if (mid == myGuess)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public int Search(int[] nums, int target)
        {
            var start = 0;
            var end = nums.Length - 1;

            while (start <= end)
            {
                var midIndex = start + (end - start) / 2;

                if (nums[midIndex] == target)
                {
                    return midIndex;
                }
                else if (nums[midIndex] >= nums[start])
                {
                    if (target >= nums[start] && target < nums[midIndex])
                    {
                        end = midIndex - 1;
                    }
                    else
                    {
                        start = midIndex + 1;
                    }
                }
                else
                {
                    if (target <= nums[end] && target > nums[midIndex])
                    {
                        start = midIndex + 1;
                    }
                    else
                    {
                        end = midIndex - 1;
                    }
                }
            }

            return -1;
        }

        public int[] GetMilestoneDays(int[] revenues, int[] milestones)
        {
            Array.Sort(milestones);
            var output = new List<int>();
            var indMileStones = 0;
            var totalRevenue = 0;
            for (int i = 0; i < revenues.Length; i++)
            {
                totalRevenue += revenues[i];
                if (totalRevenue >= milestones[indMileStones])
                {
                    output.Add(i + 1);
                    indMileStones++;
                    if (indMileStones > revenues.Length - 1)
                        return output.ToArray();
                }
            }
            // Write your code here
            return output.ToArray();
        }

        public int[] CountSubArrays(int[] arr)
        {
            var output = new List<int>();

            for (int i = 0; i < arr.Length; i++)
            {
                var countSubArrays = 1;
                var prevIndx = i;
                while (prevIndx - 1 >= 0)
                {
                    if (arr[prevIndx - 1] > arr[i])
                    {
                        break;
                    }
                    prevIndx--;
                }
                countSubArrays += i - (prevIndx > 0 ? prevIndx : 0);

                var nextIndx = i;
                while (nextIndx + 1 < arr.Length)
                {
                    if (arr[nextIndx + 1] > arr[i])
                    {
                        break;
                    }
                    nextIndx++;
                }
                countSubArrays += (nextIndx > 0 ? nextIndx : 0) - i;
                output.Add(countSubArrays);
            }

            return output.ToArray();
        }

        public int GetBillionUsersDay(float[] growthRates)
        {
            var start = 0;
            var end = 200;
            long previousSum = 1_000_000_001;

            while (start < end)
            {
                var mid = start + (end - start) / 2;

                var currentSum = CalculateSum(growthRates, mid);

                if ((currentSum >= 1000000000 && previousSum >= 1000000000) || (currentSum <= 1000000000 && previousSum <= 1000000000) || currentSum == 1000000000)
                {
                    return mid;
                }
                else if (currentSum < 1000000000)
                {
                    start = mid + 1;
                }
                else
                {
                    end = mid - 1;
                }
                previousSum = currentSum;
            }
            return -1;
        }

        private long CalculateSum(float[] growthRates, int power)
        {
            var sum = 0.0;
            foreach (var item in growthRates)
            {
                sum += Math.Pow(item, power);
            }
            return (long)sum;
        }

        public int MinProduct(int a, int b)
        {
            int smaller = a < b ? a : b;
            int bigger = a < b ? b : a;
            return MinProductHelper(smaller, bigger);
        }

        private int MinProductHelper(int smaller, int bigger)
        {
            if (smaller == 0) return 0;
            if (smaller == 1) return bigger;

            int half = smaller / 2;
            int halfProduct = MinProductHelper(half, bigger);

            if (smaller % 2 == 0)
            {
                return halfProduct + halfProduct;
            }
            else
            {
                return halfProduct + halfProduct + bigger;
            }
        }
    }
}