using System.Collections.Generic;
using System;
using UnityEngine;

namespace CardGame
{
    public class Player
    {
        private Dictionary<string, int> collectedRewards;

      
        public void ResetRewards()
        {

            collectedRewards.Clear();
        }
        public void AddReward(Reward reward)
        {
            if (collectedRewards.ContainsKey(reward.name))
                collectedRewards[reward.name] += reward.value;
            else
                collectedRewards.Add(reward.name, reward.value);
        }

    }

}