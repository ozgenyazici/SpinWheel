using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace CardGame
{
    public class WheelManager : MonoBehaviour, ICompleteable
    {
        public enum State { Idle, Spining };
        public State state;

        public SpinWheelDataEvent OnSpinWheelDataEvent = new SpinWheelDataEvent();

        public event Action<Reward> Collected;
        public event Action Completed;

        public WheelDataSO bronzeSpinWheelData;
        public WheelDataSO silverSpinWheelData;
        public WheelDataSO goldenSpinWheelData;

        [SerializeField] private List<RewardBehaviour> rewardBehaviourList;

        [SerializeField] private LevelFactory levelFactory;
        [SerializeField] private RewardManager rewardManager;
        [SerializeField] private SpinBehaviour spinBehaviour;

        [SerializeField] private WheelDataSO _currentSpinWheelData;
        [SerializeField] private Transform collectTransform;

        private const float collectDuration = 1f;

        private Reward collectedReward;

        public List<Reward> rewardList;




        private void Awake()
        {
            spinBehaviour.SpinEnded += RewardAnim;
        }
        public void SetReward()
        {
            int rndmRange = UnityEngine.Random.Range(0, rewardList.Count);
            collectedReward = rewardList[rndmRange];
            spinBehaviour.StartSpin(collectedReward.id, rewardList.Count);
        }
        public WheelDataSO GetCurrentWheelData()
        {
            return _currentSpinWheelData;
        }

        public void RewardAnim()
        {
            Image rewardImage = GetRewardBehaviour().iconRenderer;
            Vector2 maxScale = new Vector2(2f, 2f);
            rewardImage.transform.DOScale(maxScale, collectDuration).SetEase(Ease.OutQuad).onComplete = CollectEndHandler;
            //rewardImage.transform.DOMove(collectTransform.position, collectDuration).onComplete = CollectEndHandler;
        }


        private void CollectEndHandler()
        {
            Completed?.Invoke();

            bool isBomb = GameManager.Instance.HandleReward(collectedReward);
            GetRewardBehaviour().ResetTransform();

            if (!isBomb)
                Collected?.Invoke(collectedReward);
            else
                GameManager.Instance.CallEvent();
        }
        public RewardBehaviour GetRewardBehaviour()
        {
            foreach (RewardBehaviour reward in rewardBehaviourList)
            {
                if (reward.data.id == collectedReward.id)
                    return reward;
            }

            return null;
        }
        public void SetWheel(int round)
        {
            LevelDataSO levelDataSO = levelFactory.GetLevelData(round);
            rewardList = levelDataSO.rewards;
            _currentSpinWheelData = levelDataSO.wheelData;

            int count = 0;

            foreach (RewardBehaviour rewardBehaviour in rewardBehaviourList)
            {
                Reward reward = levelDataSO.rewards[count];
                rewardBehaviour.Initialize(reward);
                levelFactory.GetReward(reward.id);
                count++;

            }

            OnSpinWheelDataEvent.Invoke(_currentSpinWheelData);
        }
    }


}