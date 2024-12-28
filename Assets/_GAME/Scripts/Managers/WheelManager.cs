using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
namespace CardGame
{
    public class WheelManager : MonoBehaviour, ICompleteable
    {
        public enum State { Idle, Spining };
        public State state;

        public SpinWheelDataEvent OnSpinWheelDataEvent = new SpinWheelDataEvent();

        public event Action<Reward> Collected;
        public event Action Completed;


        [SerializeField] private List<RewardBehaviour> rewardBehaviourList;

        [SerializeField] private LevelFactory levelFactory;
        [SerializeField] private RewardManager rewardManager;
        [SerializeField] private SpinBehaviour spinBehaviour;

        [SerializeField] private WheelDataSO _currentSpinWheelData;
        [SerializeField] private Transform collectTransform;

        private const float collectDuration = 1f;

        private Reward collectedReward;

        private List<Reward> rewardList;

        [Header("UI")]
        [SerializeField] private WheelRewardView _rewardView;
        private WheelRewardPresenter _rewardPresenter;

        [SerializeField] private WheelNameView _nameView;
        private WheelNamePresenter _namePresenter;

        private void Awake()
        {
            _namePresenter = new WheelNamePresenter(this, _nameView);
            _rewardPresenter = new WheelRewardPresenter(_rewardView);

            spinBehaviour.SpinEnded += RewardAnim;
        }
        public void SetReward()
        {
            List<WeightedNumber> rewardWeights = new List<WeightedNumber>();

            for (int i = 0; i < rewardList.Count; i++)
            {
                rewardWeights.Add(new WeightedNumber(i, rewardList[i].weight));
            }

            int selectedReward = RandomWeighted.PickRandom(rewardWeights.ToArray());

            collectedReward = rewardList[selectedReward];
            spinBehaviour.StartSpin(collectedReward.id, rewardList.Count);
        }
        public WheelDataSO GetCurrentWheelData()
        {
            return _currentSpinWheelData;
        }

        public void RewardAnim()
        {

            _rewardPresenter.UpdateView(collectedReward.name, collectedReward.value, _currentSpinWheelData.textColor);

            Image rewardImage = GetRewardBehaviour().iconRenderer;
            Vector2 maxScale = new Vector2(2f, 2f);
            rewardImage.transform.DOScale(maxScale, collectDuration).SetEase(Ease.OutQuad).onComplete = CollectEndHandler;
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

            _namePresenter.UpdateView();
            OnSpinWheelDataEvent.Invoke(_currentSpinWheelData);
        }

        public List<Reward> GetRewardList()
        {
            return rewardList;
        }
    }


}