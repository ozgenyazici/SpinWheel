using System.Collections.Generic;
using System;
using UnityEngine;
namespace CardGame
{
    public class Player
    {
        private Dictionary<string, int> collectedRewards = new Dictionary<string, int>();
        private int Coin;

        public void ResetRewards()
        {
            collectedRewards.Clear();
        }
        public void ClaimRewards(Dictionary<string, int> rewards)
        {
            foreach (var reward in rewards)
            {
                if (collectedRewards.ContainsKey(reward.Key))
                    collectedRewards[reward.Key] += reward.Value;
                else
                    collectedRewards.Add(reward.Key, reward.Value);
            }

        }





    }

    public class Currency
    {
        private const int minCurrency = 0;
    }
}