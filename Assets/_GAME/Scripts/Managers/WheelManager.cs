using System.Collections.Generic;
using UnityEngine;
using System;


namespace CardGame
{
    public class WheelManager : MonoBehaviour
    {
        public SpinWheelDataEvent OnSpinWheelDataEvent = new SpinWheelDataEvent();

        public WheelDataSO bronzeSpinWheelData;
        public WheelDataSO silverSpinWheelData;
        public WheelDataSO goldenSpinWheelData;


        [SerializeField] private List<RewardBehaviour> rewardBehaviourList;

        [SerializeField] private LevelFactory levelFactory;
        [SerializeField] private RewardManager rewardManager;
        [SerializeField] private SpinBehaviour spinBehaviour;

        [SerializeField] private WheelDataSO _currentSpinWheelData;


        public List<Reward> selectedItemList;

        public event Action Collect;

        private void Awake()
        {
            SetWheel();
        }
        public void SetReward()
        {
            /*
            int rndmRange = UnityEngine.Random.Range(0, rewardList.Count);
            collectableReward = rewardList[rndmRange];
            spinBehaviour.StartSpin(collectableReward.id, rewardList.Count);*/
        }
        public WheelDataSO GetCurrentWheelData()
        {
            return _currentSpinWheelData;
        }

        private void SetWheel()
        {

            LevelDataSO levelDataSO = levelFactory.GetLevelData(5);
            selectedItemList = levelDataSO.rewards;
            _currentSpinWheelData = levelDataSO.wheelData;
            
            int count = 0;

            foreach (RewardBehaviour rewardBehaviour in rewardBehaviourList)
            {
                Reward reward = levelDataSO.rewards[count];
                rewardBehaviour.Initialize(reward);
                levelFactory.GetReward(reward.name);
                count++;

            }

            OnSpinWheelDataEvent.Invoke(_currentSpinWheelData);
        }
        /*
        private List<RewardDataSO> SetWheelList(int round)
        {
            selectedItemList.Clear();


            if (round % 30 == 0)
            {
                _currentSpinWheelData = goldenSpinWheelData;

                List<RewardDataSO> tempList = new List<RewardDataSO>(_currentSpinWheelData.rewards);

                for (int i = 0; i < 8; i++)
                {
                    if (tempList.Count == 0)
                        break;

                    int randomIndex = UnityEngine.Random.Range(0, tempList.Count);
                    selectedItemList.Add(tempList[randomIndex]);
                    tempList.RemoveAt(randomIndex);
                }


            }
            else if (round % 5 == 0)
            {
                _currentSpinWheelData = silverSpinWheelData;
                List<RewardDataSO> tempList = new List<RewardDataSO>(_currentSpinWheelData.rewards);

                for (int i = 0; i < 8; i++)
                {
                    if (tempList.Count == 0)
                        break;

                    int randomIndex = UnityEngine.Random.Range(0, tempList.Count);
                    selectedItemList.Add(tempList[randomIndex]);
                    tempList.RemoveAt(randomIndex);
                }
            }
            else
            {
                _currentSpinWheelData = bronzeSpinWheelData;
                List<RewardDataSO> tempList = new List<RewardDataSO>(_currentSpinWheelData.rewards);

                selectedItemList.Add(_currentSpinWheelData.bomb);

                for (int i = 0; i < 7; i++)
                {
                    if (_currentSpinWheelData.rewards.Count == 0)
                        break;

                    int randomIndex = UnityEngine.Random.Range(0, tempList.Count);
                    selectedItemList.Add(tempList[randomIndex]);
                    tempList.RemoveAt(randomIndex); // Seçilen itemı geçici listeden çıkar
                }
            }

            ShuffleList(selectedItemList);

            OnSpinWheelDataEvent.Invoke(_currentSpinWheelData);

            //_currentSpinWheelData.rewards;
            return _selectionStrategy.SelectRewards(_currentSpinWheelData.rewards, round);
        }

        public void ShuffleList<T>(List<T> list)
        {
            System.Random rng = new System.Random();
            int n = list.Count;

            for (int i = n - 1; i > 0; i--)
            {
                int randomIndex = rng.Next(0, i + 1);
                T temp = list[i];
                list[i] = list[randomIndex];
                list[randomIndex] = temp;
            }
        }*/
    }
}