using UnityEngine;
namespace CardGame
{
    public class GameUI : MonoBehaviour
    {
        IFailable _failable;

        [SerializeField] private GameManager _gameManager;


        [SerializeField] private GamePopupUI _failPopup;

        private void Awake()
        {
            _failable = _gameManager.GetComponent<IFailable>();

        }
        private void OnEnable()
        {
            _failable.Failed += FailGame;
            _failPopup.ReviveButtonPressed += ReviveGame;
            _failPopup.GiveUpButtonPressed += GiveUpGame;
        }
        private void OnDisable()
        {
            _failable.Failed -= FailGame;
            _failPopup.ReviveButtonPressed -= ReviveGame;
            _failPopup.GiveUpButtonPressed -= GiveUpGame;

        }
        private void FailGame()
        {
            _failPopup.Show(true);
        }
        private void ReviveGame()
        {
            _failPopup.Show(false);
            _gameManager.Restart();
        }
        private void GiveUpGame()
        {
            _failPopup.Show(false);
            _gameManager.GameOver();
        }
    }

}