using System.Collections.Generic;
using UnityEngine;

namespace CardGame
{
    public static class RandomWeighted
    {
        private static Dictionary<string, float> itemsWithWeight = new Dictionary<string, float>();

        public static int PickRandom(params WeightedNumber[] rewards)
        {
            float totalWeight = 0f;
            foreach (var reward in rewards)
            {
                totalWeight += reward.percentage;
            }

            float randomValue = Random.Range(0, totalWeight);
            float cumulativeWeight = 0f;

            foreach (var reward in rewards)
            {
                cumulativeWeight += reward.percentage;
                if (randomValue < cumulativeWeight)
                {
                    return reward.number;
                }
            }

            return 0;
        }
    }


    public class WeightedNumber
    {
        public int number;
        public float percentage;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="num">Number</param>
        /// <param name="percen">Percentage of the number appearance</param>
        public WeightedNumber(int num, float percen)
        {
            number = num;
            percentage = percen;
        }
    }

}