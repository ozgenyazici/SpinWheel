using System;
using UnityEngine;


namespace CardGame
{
    public class GameManager : MonoBehaviour, IFailable, IRestartable, ICompleteable
    {
        public static GameManager Instance;

        [SerializeField] private WheelManager wheelManager;
        [SerializeField] private SpinBehaviour spinBehaviour;
        private Player _player;
        private int _currentRound = 1;

        public event Action Failed;
        public void Complete() => CompleteGame();
        public void Restart() => StartGame();

        void Awake()
        {

            Application.targetFrameRate = 60;
            if (Instance == null)
                Instance = this;
            else if (Instance != this)
                Destroy(gameObject);

            DontDestroyOnLoad(this);



            _player = new Player();
            wheelManager.Collected += UpdateRound;

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
        public void CompleteGame()
        {
            UpdateRound();
            SetupGame();
        }
        public void GameOver() { }

        public void UpdateRound() { _currentRound++; }

        public void HandleReward(Reward reward)
        {
            if (reward.isBomb)
                Failed?.Invoke();

        }

    }

}