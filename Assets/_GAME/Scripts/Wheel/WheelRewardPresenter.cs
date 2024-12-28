using UnityEngine;
namespace CardGame
{
    public class WheelRewardPresenter
    {
        private WheelRewardView _view;
        public WheelRewardPresenter(WheelRewardView view)
        {
            this._view = view;

            UpdateView();
        }
        public void UpdateView(string name = "", int index = 0, Color color = default)
        {
            _view.UpdateText(name, index);
            _view.UpdateTextColor(color);
        }
    }
}