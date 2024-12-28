namespace CardGame
{
    public class WheelNamePresenter
    {
        private WheelNameView _view;
        private WheelManager _manager;
        public WheelNamePresenter(WheelManager manager, WheelNameView view)
        {
            this._manager = manager;
            this._view = view;

            UpdateView();
        }
        public void UpdateView()
        {
            if (_manager.GetCurrentWheelData() == null)
                return;


            _view.UpdateText(_manager.GetCurrentWheelData().name);
            _view.UpdateTextColor(_manager.GetCurrentWheelData().textColor);
        }
    }
}