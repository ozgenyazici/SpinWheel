using UnityEngine;
using UnityEngine.UI;
namespace CardGame
{
    public class WheelButton : MonoBehaviour
    {
        [SerializeField] private WheelManager wheelManager;
        [SerializeField] private SpinBehaviour spinBehaviour;
        [SerializeField] private Button button;

        void OnValidate()
        {
            if (button != null)
            {
                button.onClick.AddListener(SpinEventListener);
            }
            wheelManager.Collected += SpinEndedHandler;
            //spinBehaviour.SpinEnded += SpinEndedHandler;
        }
        private void SpinEventListener()
        {
            button.interactable = false;

            wheelManager.SetReward();
        }

        private void SpinEndedHandler()
        {
            button.interactable = true;

        }
    }


}