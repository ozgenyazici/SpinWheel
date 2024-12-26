using System.Collections.Generic;
using UnityEngine;
using System;


namespace CardGame
{
    public class WheelManager : MonoBehaviour
    {
        [SerializeField] private List<RewardBehaviour> rewardBehaviourList;
        [SerializeField] private RewardFactory rewardFactory;
        [SerializeField] private RewardManager rewardManager;
        private List<IReward> rewardList;
        private IReward collectableReward;

        public event Action Collect;


        private void Awake()
        {
            SetRewardList();
        }

        private void SetRewardList()
        {
            IReward reward;
            int rewardID = 6;
            rewardList = new List<IReward>();

            foreach (RewardBehaviour rewardBehaviour in rewardBehaviourList)
            {

                reward = rewardFactory.GetReward(rewardID);
                rewardBehaviour.Initialize(reward);
                rewardList.Add(reward);
                //rewardID++;


            }
        }
    }
}