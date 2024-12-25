using System.Collections.Generic;
using UnityEngine;
using System.Linq;


namespace CardGame
{
    public class GameManager : MonoBehaviour
    {
        public SpinWheelData bronzeSpinWheelData;
        public SpinWheelData silverSpinWheelData;
        public SpinWheelData goldenSpinWheelData;

        void Start()
        {
            RewardManager.Instance.bronzeSpinWheelData = bronzeSpinWheelData;
            RewardManager.Instance.silverSpinWheelData = silverSpinWheelData;
            RewardManager.Instance.goldenSpinWheelData = goldenSpinWheelData;

            PlayGame(30);
        }

        void PlayGame(int totalRounds)
        {
            for (int round = 1; round <= totalRounds; round++)
            {
                Debug.Log($"Round {round}");
                List<Reward> selectedRewards = RewardManager.Instance.SetupSpin(round);
                Debug.Log($"Selected Rewards for Round {round}: {string.Join(", ", selectedRewards.Select(r => r.rewardName))}");
            }

            UpdateSpinWheelUI();
        }

        private void UpdateSpinWheelUI()
        {
            Sprite bgSprite = RewardManager.Instance.GetBackgroundSprite();
            Sprite indicatorSprite = RewardManager.Instance.GetIndicatorSprite();
        }
    }

}