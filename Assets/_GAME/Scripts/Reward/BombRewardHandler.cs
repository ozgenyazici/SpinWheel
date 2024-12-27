using System;
using UnityEngine;
namespace CardGame
{
    public class BombRewardHandler : MonoBehaviour, IRewardHandler, IFailable
    {
        public event Action Failed;

        public void HandleReward(Reward reward)
        {
            UnityEngine.Debug.Log($"Reward name {reward.name} bomb : {reward.isBomb}");

            if (reward.isBomb)
                Failed?.Invoke();

        }

    }
}