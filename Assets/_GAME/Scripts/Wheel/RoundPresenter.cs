namespace CardGame
{
    public class RoundPresenter
    {
        private GameManager _gameManager;
        private RoundView _view;

        public RoundPresenter(GameManager gameManager, RoundView view)
        {
            this._gameManager = gameManager;
            this._view = view;

            UpdateView();
        }
        public void UpdateView()
        {
            _view.UpdateRoundText(_gameManager.GetRound());
        }
    }

}