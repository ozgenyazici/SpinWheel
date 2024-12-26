using System.Collections.Generic;
using UnityEngine;


namespace CardGame
{
    public class RewardManager : MonoBehaviour
    {
        public WheelDataSO bronzeSpinWheelData;
        public WheelDataSO silverSpinWheelData;
        public WheelDataSO goldenSpinWheelData;

        private IRewardSelection _selectionStrategy;
        [SerializeField] private WheelDataSO _currentSpinWheelData;


        public SpinWheelDataEvent OnSpinWheelDataEvent = new SpinWheelDataEvent();

        private RewardDataSO rewardDummy;

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

        private RewardDataSO RewardItem(int id)
        {
            SetupWheel(1);

            foreach (RewardDataSO reward in _currentSpinWheelData.rewards)
            {
                if (reward.id == id)
                    return reward;
            }

            return rewardDummy;
        }

        public List<RewardDataSO> SetupWheel(int round)
        {
            if (round % 30 == 0)
            {
                _currentSpinWheelData = goldenSpinWheelData;
            }
            else if (round % 5 == 0)
            {
                _currentSpinWheelData = silverSpinWheelData;
            }
            else
            {
                _currentSpinWheelData = bronzeSpinWheelData;
            }

            OnSpinWheelDataEvent.Invoke(_currentSpinWheelData);

            return _currentSpinWheelData.rewards;//_selectionStrategy.SelectRewards(_currentSpinWheelData.rewards, round);
        }

        public Sprite GetBackgroundSprite()
        {
            return _currentSpinWheelData.bgSprite;
        }

        public Sprite GetIndicatorSprite()
        {
            return _currentSpinWheelData.indicatorSprite;
        }
    }
}