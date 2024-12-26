using UnityEngine;


namespace CardGame
{
    public class GameManager : MonoBehaviour
    {
        public WheelDataSO bronzeSpinWheelData;
        public WheelDataSO silverSpinWheelData;
        public WheelDataSO goldenSpinWheelData;

        void Start()
        {
            //  RewardManager.Instance.bronzeSpinWheelData = bronzeSpinWheelData;
            //  RewardManager.Instance.silverSpinWheelData = silverSpinWheelData;
            // RewardManager.Instance.goldenSpinWheelData = goldenSpinWheelData;

            PlayGame(30);
        }

        void PlayGame(int totalRounds)
        {
            for (int round = 1; round <= totalRounds; round++)
            {
                // List<Reward> selectedRewards = RewardManager.Instance.SetupSpin(round);
                //Debug.Log($"Selected Rewards for Round {round}: {string.Join(", ", selectedRewards.Select(r => r.name))}");
            }

            UpdateSpinWheelUI();
        }

        private void UpdateSpinWheelUI()
        {
            //   Sprite bgSprite = RewardManager.Instance.GetBackgroundSprite();
            //   Sprite indicatorSprite = RewardManager.Instance.GetIndicatorSprite();
        }
    }
}