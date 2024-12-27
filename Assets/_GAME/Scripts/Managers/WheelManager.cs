using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace CardGame
{
    public class WheelManager : MonoBehaviour, IFailable
    {
        public SpinWheelDataEvent OnSpinWheelDataEvent = new SpinWheelDataEvent();

        public event Action Collected;
        public event Action Failed;

        public WheelDataSO bronzeSpinWheelData;
        public WheelDataSO silverSpinWheelData;
        public WheelDataSO goldenSpinWheelData;


        [SerializeField] private List<RewardBehaviour> rewardBehaviourList;

        [SerializeField] private LevelFactory levelFactory;
        [SerializeField] private RewardManager rewardManager;
        [SerializeField] private SpinBehaviour spinBehaviour;

        [SerializeField] private WheelDataSO _currentSpinWheelData;
        [SerializeField] private Transform collectTransform;

        private IRewardHandler _rewardHandler;



        private const float collectDuration = 1f;

        private Reward collectedReward;

        public List<Reward> rewardList;


        private void Awake()
        {
            spinBehaviour.SpinEnded += CollectReward;
        }
        public void SetReward()
        {

            int rndmRange = UnityEngine.Random.Range(0, rewardList.Count);
            collectedReward = rewardList[rndmRange];
            Debug.Log($"SetReward {collectedReward.name} id { collectedReward.id}");
            spinBehaviour.StartSpin(collectedReward.id, rewardList.Count);
        }
        public WheelDataSO GetCurrentWheelData()
        {
            return _currentSpinWheelData;
        }


        public void CollectReward()
        {
            Image rewardImage = GetRewardBehaviour().iconRenderer;
            Vector2 maxScale = new Vector2(2f, 2f);
            rewardImage.transform.DOScale(maxScale, collectDuration).SetEase(Ease.OutBack).onComplete = CollectEndHandler;
            //rewardImage.transform.DOMove(collectTransform.position, collectDuration).onComplete = CollectEndHandler;
        }


        private void CollectEndHandler()
        {
            _rewardHandler.HandleReward(collectedReward);

            GetRewardBehaviour().ResetTransform();
            Collected?.Invoke();

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