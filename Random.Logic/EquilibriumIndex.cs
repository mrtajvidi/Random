using System;
using System.Collections.Generic;
using System.Text;

namespace Random.Logic
{
    public class EquilibriumIndex
    {

        public void ReturnEquilibriumIndex(int[] inputs)
        {
            if (inputs == null || inputs.Length == 0)
                return;

            var totalSum = 0;
            var sumPrefix = 0;

            var sumPrefixes = new int[inputs.Length];

            for (int i = 0; i < inputs.Length; i++)
            {
                sumPrefixes[i] = totalSum;
                totalSum += inputs[i];
            }

            var sumSuffix = new int[inputs.Length];

            for (int i = 0; i < inputs.Length; i++)
            {
                sumSuffix[i] = totalSum - sumPrefixes[i] - inputs[i];
            }

        }
    }
}
