using System.Collections.Generic;
using Xunit;

namespace Random.Tests
{
    public class RandomTest
    {
        private readonly Logic.Random _random;

        public RandomTest()
        {
            _random = new Logic.Random();
        }

        [Fact]
        public void TwoSum_FirstCase_True()
        {
            var input = new int[] { 2, 7, 11, 15 };
            var target = 9;
            var output = new int[] { 0, 1 };

            var actualOutput = _random.TwoSum(input, target);

            Assert.Equal(output, actualOutput);
        }

        [Fact]
        public void TwoSum_SecondCase_True()
        {
            var input = new int[] { 3, 2, 4 };
            var target = 6;
            var output = new int[] { 1, 2 };

            var actualOutput = _random.TwoSum(input, target);

            Assert.Equal(output, actualOutput);
        }

        [Fact]
        public void TwoSum_ThirdCase_True()
        {
            var input = new int[] { 3, 3 };
            var target = 6;
            var output = new int[] { 0, 1 };

            var actualOutput = _random.TwoSum(input, target);

            Assert.Equal(output, actualOutput);
        }

        [Fact]
        public void TwoSum_ForthCase_True()
        {
            var input = new int[] { 230, 863, 916, 585, 981, 404, 316, 785, 88, 12, 70, 435, 384, 778,
                887, 755, 740, 337, 86, 92, 325, 422, 815, 650, 920, 125, 277, 336, 221, 847, 168, 23,
                677, 61, 400, 136, 874, 363, 394, 199, 863, 997, 794, 587, 124, 321, 212, 957, 764, 173,
                314, 422, 927, 783, 930, 282, 306, 506, 44, 926, 691, 568, 68, 730, 933, 737, 531, 180,
                414, 751, 28, 546, 60, 371, 493, 370, 527, 387, 43, 541, 13, 457, 328, 227, 652, 365, 430,
                803, 59, 858, 538, 427, 583, 368, 375, 173, 809, 896, 370, 789 };
            var target = 542;
            var output = new int[] { 0, 1 };

            var actualOutput = _random.TwoSum(input, target);

            Assert.Equal(output, actualOutput);
        }

        [Theory]
        [InlineData("abcabcbb", 3)]
        [InlineData("pwwkew", 3)]
        [InlineData("bbbbb", 1)]
        [InlineData(" ", 1)]
        [InlineData("", 0)]
        //[InlineData("aab", 2)]
        public void LengthOfLongestSubstring_SecondCase_True(string input, int expectedOutput)
        {
            var actualOutput = _random.LengthOfLongestSubstring(input);

            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void MaxArea_FirstCase_True()
        {
            var input = new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
            var expectedOutput = 49;
            var actualOutput = _random.MaxArea(input);
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Theory]
        [InlineData(3, "III")]
        [InlineData(0, "")]
        [InlineData(4, "IV")]
        [InlineData(9, "IX")]
        [InlineData(8, "VIII")]
        [InlineData(58, "LVIII")]
        [InlineData(1994, "MCMXCIV")]
        public void IntToRoman_FirstCase_True(int input, string expectedOutput)
        {
            var actualOutput = _random.IntToRoman(input);
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Theory]
        //[InlineData("III", 3)]
        //[InlineData("" , 0)]
        //[InlineData("IV", 4)]
        //[InlineData("IX", 9)]
        //[InlineData("VIII", 8)]
        //[InlineData("LVIII", 58)]
        [InlineData("MCMXCIV", 1994)]
        public void RomanToInt_FirstCase_True(string input, int expectedOutput)
        {
            var actualOutput = _random.RomanToInt(input);
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Theory]
        //[InlineData("hello", "ll", 2)]
        //[InlineData("aaabaa", "baa", 3)]
        //[InlineData("", "", 0)]
        [InlineData("", "a", -1)]
        public void StrStr_FirstCase_True(string haystack, string needle, int expectedOutput)
        {
            var actualOutput = _random.StrStr(haystack, needle);
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void NumTeams_FirstCase_True()
        {
            var input = new int[] { 2, 5, 3, 4, 1 };
            var actualOutput = _random.NumTeams(input);
            var expectedOutput = 3;
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void NumTeams_SecondCase_True()
        {
            var input = new int[] { 2, 1, 3 };
            var actualOutput = _random.NumTeams(input);
            var expectedOutput = 0;
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void NumTeams_thirdCase_True()
        {
            var input = new int[] { 1, 2, 3, 4 };
            var actualOutput = _random.NumTeams(input);
            var expectedOutput = 4;
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Theory]
        [InlineData("1.01", "1.001", 0)]
        [InlineData("1.0", "1.0.0", 0)]
        [InlineData("0.1", "1.1", -1)]
        [InlineData("1.0.1", "1", 1)]
        [InlineData("7.5.2.4", "7.5.3", -1)]
        public void CompareVersion_thirdCase_True(string version1, string version2, int expectedOutput)
        {
            var actualOutput = _random.CompareVersion(version1, version2);
            Assert.Equal(expectedOutput, actualOutput);
        }

        //[Theory]
        //[InlineData(123, "one hundred twenty three")]
        //[InlineData(109, "one hundred nine")]
        //[InlineData(100, "one hundred")]
        //[InlineData(99, "ninety nine")]
        //[InlineData(9, "nine")]
        //[InlineData(0, "zero")]
        //public void NumberToWords_thirdCase_True(int number, string expectedOutput)
        //{
        //    var actualOutput = _random.NumberToWords(number);
        //    Assert.Equal(expectedOutput, actualOutput);
        //}

        [Theory]
        [InlineData(1, 0)]
        [InlineData(2, 1)]
        [InlineData(3, 1)]
        [InlineData(1, 1)]
        public void FibonacciDynamicPro_Case_True(int number, int expectedOutput)
        {
            var actualOutput = _random.FibonacciDynamicProgrammingTopBottom(new int[number], number);
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 1)]
        [InlineData(3, 1)]
        [InlineData(0, 0)]
        public void FibonacciDynamicPro_BottomUp_True(int number, int expectedOutput)
        {
            var actualOutput = _random.FibonacciDynamicProgrammingBottomUp(number);
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void GetNewValue_Case1_True()
        {
            var input = new int[] { 1, 0, 0, 0, 0, 1, 0, 0 };
            var days = 1;
            var expectedOutput = new int[] { 0, 1, 0, 0, 1, 0, 1, 0 };
            var actualOutput = _random.CellCompete(input, days);
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void GetNewValue_Case2_True()
        {
            var input = new int[] { 1, 1, 1, 0, 1, 1, 1, 1 };
            var days = 2;
            var expectedOutput = new int[] { 0, 0, 0, 0, 0, 1, 1, 0 };
            var actualOutput = _random.CellCompete(input, days);
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void finalInstances_Case2_True()
        {
            var input = new List<int> { 1, 3, 5, 10, 80 };
            var instances = 1;
            var expectedOutput = 2;
            var actualOutput = _random.finalInstances(instances, input);
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void finalInstances_Case1_True()
        {
            var input = new List<int> { 25, 23, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 76, 80 };
            var instances = 2;
            var expectedOutput = 2;
            var actualOutput = _random.finalInstances(instances, input);
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void abbas()
        {
            var input = "|**|*|*";

            var start = new List<int> { 1, 1 };
            var end = new List<int> { 5, 6 };

            var expectedOutput = new List<int> { 2, 3 };
            var actualOutput = _random.numberOfItems(input, start, end);
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void MaxPair_Naive_FirstCase()
        {
            var numbers = new int[] { 5, 6, 2, 7, 4 };

            var expectedOutput = 42;
            var actualOutput = _random.GetMaxPairwiseProduct(numbers);
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void MaxPair_Fast_FirstApproach()
        {
            var rnd = new System.Random(5000000);
            var numbers = new int[1000000];
            for (int i = 0; i < 100000; i++)
            {
                numbers[i] = rnd.Next(5000000);
            }

            //var input = new int[] { 5, 6, 2, 7, 4 };
            var expectedOutput = 42;
            var (actualOutput, elapsedTime) = _random.GetMaxPairwiseProductFast(numbers);
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void MaxPair_Compact_FirstApproach()
        {
            //var rnd = new System.Random(1000);
            //var length = 100000;

            //var input = new int[length];
            //for (int i = 0; i < length; i++)
            //{
            //    input[i] = rnd.Next(length);
            //}

            var numbers = new int[] { 5, 6, 2, 7, 4 };
            // var test = string.Join(',', input);

            var expectedOutput = 42;
            var (actualOutput, elapsedTime) = _random.GetMaxPairwiseProductCompact(numbers);
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Theory]
        [InlineData("1432219", 3, "1219")]
        // [InlineData("10", 1, "0")]
        public void RemoveKDigits_Compact_FirstApproach(string numbers, int k, string expectedOutput)
        {
            var actualOutput = _random.RemoveKDigits(numbers, k);
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Theory]
        [InlineData("A man, a plan, a canal: Panama", true)]
        [InlineData("race a car", false)]
        [InlineData(".", true)]
        [InlineData(".,", true)]
        public void IsPalindrome(string input, bool expectedOutput)
        {
            var actualOutput = _random.IsPalindrome(input);
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void ReverseString_FirstCase()
        {
            var input = new char[] { 'h', 'e', 'l', 'l', 'o' };
            var expectedOutput = new char[] { 'o', 'l', 'l', 'e', 'h' };

            _random.ReverseString(input);
            Assert.Equal(expectedOutput, input);
        }

        [Fact]
        public void ReverseString_SecondCase()
        {
            var input = new char[] { 'H', 'a', 'n', 'n', 'a', 'h' };
            var expectedOutput = new char[] { 'h', 'a', 'n', 'n', 'a', 'H' };

            _random.ReverseString(input);
            Assert.Equal(expectedOutput, input);
        }

        [Theory]
        [InlineData("42", 42)]
        [InlineData("   -42", -42)]
        [InlineData("4193 with words", 4193)]
        [InlineData("words and 987", 0)]
        [InlineData("-91283472332", -2147483647)]
        public void MyAtoi_Works_True(string input, int expectedOutput)
        {
            var actualOutput = _random.MyAtoi(input);
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Theory]
        [InlineData("()", true)]
        [InlineData("()[]{}", true)]
        [InlineData("(]", false)]
        [InlineData("([)]", false)]
        [InlineData("{[]}", true)]
        public void IsValid_Works_True(string input, bool expectedOutput)
        {
            var actualOutput = _random.IsValid(input);
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void GroupAnagrams_SecondCase()
        {
            var input = new[] { "eat", "tea", "tan", "ate", "nat", "bat" };

            var expectedOutput = new List<List<string>>();

            expectedOutput.Add(new List<string>() { "eat", "tea", "ate" });
            expectedOutput.Add(new List<string>() { "nat", "tan" });
            expectedOutput.Add(new List<string>() { "bat" });

            var actualOutput = _random.GroupAnagrams(input);
            Assert.True(actualOutput[1][1] == expectedOutput[1][1]);
        }

        [Fact]
        public void SpiralOrder_SecondCase()
        {
            var input = new[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };

            var actualOutput = _random.SpiralOrder();
            Assert.Equal(actualOutput, input);
        }

        [Theory]
        [InlineData("aab", 0)]
        [InlineData("aaabbbcc", 2)]
        [InlineData("ceabaacb", 2)]
        public void MinDelete_Works_True(string input, int expectedOutput)
        {
            var actualOutput = _random.MinDeletions(input);
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Theory]
        // [InlineData("mamad", 3)]
        // [InlineData("asflkj", -1)]
        [InlineData("aabb", 2)]
        //[InlineData("ntiin", 1)]
        public void FindMinimumSwapsToMakePalindrome_Works_True(string input, int expectedOutput)
        {
            var actualOutput = _random.FindMinimumSwapsToMakePalindrome(input);
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void MergeSort_Works_True()
        {
            var input = new List<int>(){ 8, 9, 5, 4, 3, 2, 10}; 
            var expectedOutput = new List<int>(){ 2, 3, 4, 5, 8, 9, 10}; 
            var actualOutput = _random.MergeSort(input);
            Assert.Equal(expectedOutput, actualOutput);
        }


        [Fact]
        public void AreTheyEqual_Works_True()
        {
            var inputA = new int[] {1, 2, 3, 4, 5};
            var inputB = new int[] {1, 4, 3, 2, 5};
            var actualOutput = _random.AreTheyEqual(inputA, inputB);
            Assert.True(actualOutput);
        }


        [Theory]
        [InlineData("Zebra-493?", 3, "Cheud-726?")]
        [InlineData("abcdefghijklmNOPQRSTUVWXYZ0123456789", 39, "nopqrstuvwxyzABCDEFGHIJKLM9012345678")]
        public void RotationalCipher_Works_True(string input, int rotationFactor, string expectedOutput)
        {
            var actualOutput = _random.RotationalCipher(input, rotationFactor);
            Assert.Equal(expectedOutput, actualOutput);
        }       
        
        
        [Fact]
        public void GetTotalTime_Works_True()
        {
            var input = new int[] { 4, 2, 1, 3 };
            var expectedOutput = 26;
            var actualOutput = _random.GetTotalTime(input);
            Assert.Equal(expectedOutput, actualOutput);
        }
    }
}