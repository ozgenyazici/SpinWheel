using System.Collections.Generic;
using UnityEngine;


namespace CardGame
{
    public class RewardManager : MonoBehaviour
    {
        public enum RewardType { Chest, Item, Currency }
        public RewardType rewardType;

        [SerializeField] private WheelManager wheelManager;

        [SerializeField] private Reward rewardDummy = null;



        public Sprite GetIcon(string name)
        {
            return RewardItem(name).icon;
        }
        public string GetName(string name)
        {
            return RewardItem(name).name;
        }
        public int GetValue(string name)
        {
            return RewardItem(name).value;
        }


        private Reward RewardItem(string name)
        {
            foreach (Reward reward in wheelManager.selectedItemList)
            {
                if (reward.name == name)
                    return reward;
            }

            return rewardDummy;
        }

    }
}