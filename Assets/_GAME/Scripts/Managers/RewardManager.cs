using System.Collections.Generic;
using UnityEngine;


namespace CardGame
{
    public class RewardManager : MonoBehaviour
    {
        private static RewardManager _instance;
        public static RewardManager Instance => _instance ?? (_instance = new GameObject("RewardManager").AddComponent<RewardManager>());

        public SpinWheelData bronzeSpinWheelData;
        public SpinWheelData silverSpinWheelData;
        public SpinWheelData goldenSpinWheelData;

        private IRewardSelection _selectionStrategy;
        private SpinWheelData _currentSpinWheelData;


        public SpinWheelDataEvent OnSpinWheelDataEvent = new SpinWheelDataEvent();

        void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
            _selectionStrategy = new RoundBasedSelection();

        }

        public List<Reward> SetupSpin(int round)
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

            return _selectionStrategy.SelectRewards(_currentSpinWheelData.rewards, round);
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