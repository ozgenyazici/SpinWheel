using UnityEngine;
using System.Collections.Generic;
namespace CardGame
{
    public static class RewardHolder
    {
        private static Dictionary<string, int> rewardList = new Dictionary<string, int>();

        public static void AddReward(Reward reward)
        {
            if (rewardList.ContainsKey(reward.name))
                rewardList[reward.name] += reward.value;
            else
                rewardList.Add(reward.name, reward.value);


            Debug.Log($"<Color=Green> Added reward {reward.name} </color>");
        }

        public static void ClearRewards()
        {
            rewardList.Clear();
        }

        public static Dictionary<string,int> GetRewards()
        {
            return rewardList;
        }
    }

}