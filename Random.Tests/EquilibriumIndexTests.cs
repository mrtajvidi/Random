using Random.Logic;
using Xunit;

namespace Random.Tests
{
    public class EquilibriumIndexTests
    {
        private readonly EquilibriumIndex _equilibriumIndex;

        public EquilibriumIndexTests()
        {
            _equilibriumIndex = new EquilibriumIndex();
        }

        [Fact]
        public void EquilibriumIndex__ReturnTrue()
        {
            var inputs = new int[] { -1, 3, -4, 5, 1, -6, 2, 1 };
            _equilibriumIndex.ReturnEquilibriumIndex(inputs);
        }
    }
}