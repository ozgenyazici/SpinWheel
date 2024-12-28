using System;
using UnityEngine;


namespace CardGame
{
    public class GameManager : MonoBehaviour, IFailable, IRestartable
    {
        public static GameManager Instance;

        [SerializeField] private WheelManager wheelManager;
        [SerializeField] private SpinBehaviour spinBehaviour;

        [SerializeField] RoundView _roundView;
        RoundPresenter _presenter;


        private Player _player;
        private int _currentRound = 1;

        public event Action Failed;
        public void Restart() => StartGame();

        void Awake()
        {

            Application.targetFrameRate = 60;

            if (Instance == null)
                Instance = this;
            else if (Instance != this)
                Destroy(gameObject);

            DontDestroyOnLoad(this);


            _presenter = new RoundPresenter(this, _roundView);
            _player = new Player();

        }
        private void OnEnable()
        {
            wheelManager.Collected += SuccessRound;
        }
        private void OnDisable()
        {
            wheelManager.Collected -= SuccessRound;

        }

        private void Start()
        {
            StartGame();
        }
        private void StartGame()
        {
            SetupGame();
        }

        private void SetupGame()
        {
            wheelManager.SetWheel(_currentRound);

        }

        public void ResetGame()
        {
            _currentRound = SetRound(1);
            SetupGame();
            _presenter.UpdateView();

        }

        private void SuccessRound(Reward reward)
        {
            RewardHolder.AddReward(reward);

            UpdateRound();
            SetupGame();
        }

        public void ClaimAllReward()
        {
            _player.ClaimRewards(RewardHolder.GetRewards());
            RewardHolder.ClearRewards();
            ResetGame();
        }
        public void UpdateRound()
        {
            _currentRound++;
            _presenter.UpdateView();
        }

        public bool HandleReward(Reward reward)
        {
            if (reward.isBomb)
                return true;
            else
                return false;

        }

        private int SetRound(int index)
        {
            return index < 1 ? _currentRound = 1 : index;

        }

        public int GetRound()
        {
            return _currentRound;
        }

        public void CallEvent()
        {
            Failed?.Invoke();
        }
    }

}