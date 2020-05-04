using Random.Logic;
using Xunit;

namespace Random.Tests
{
    public class RansomNotesTest
    {
        private readonly RansomNotes _ransomNotes;

        public RansomNotesTest()
        {
            _ransomNotes = new RansomNotes();
        }

        [Theory]
        [InlineData("a", "b", false)]
        [InlineData("aa", "ab", false)]
        [InlineData("aa", "aab", true)]
        public void RansomNotes_StringExists_ReturnTrue(string ransomNotes, string magazine, bool expected)
        {
            var canConstruct = _ransomNotes.CanConstruct(ransomNotes, magazine);
            Assert.Equal(canConstruct, expected);
        }
    }
}