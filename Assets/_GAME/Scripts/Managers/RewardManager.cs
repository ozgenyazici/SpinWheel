using System.Collections.Generic;
using UnityEngine;


namespace CardGame
{
    public class RewardManager : MonoBehaviour
    {

        [SerializeField] private WheelManager wheelManager;

        [SerializeField] private Reward rewardDummy = null;

        public Sprite GetIcon(int id)
        {
            return RewardItem(id).icon;
        }
        public string GetName(int id)
        {
            return RewardItem(id).name;
        }
        public int GetValue(int id)
        {
            return RewardItem(id).value;
        }


        private Reward RewardItem(int id)
        {
            foreach (Reward reward in wheelManager.GetRewardList())
            {
                if (reward.id == id)
                    return reward;
            }

            return rewardDummy;
        }

        public void AddReward()
        {

        }
    }
}