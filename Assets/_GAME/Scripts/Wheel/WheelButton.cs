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

        }

        private void OnEnable()
        {
            wheelManager.Collected += SpinEndedHandler;
        }
        private void OnDisable()
        {
            wheelManager.Collected -= SpinEndedHandler;
        }
        private void SpinEventListener()
        {
            button.interactable = false;
            wheelManager.state = WheelManager.State.Spining;

            wheelManager.SetReward();
        }

        private void SpinEndedHandler(Reward reward = null)
        {
            wheelManager.state = WheelManager.State.Idle;

            button.interactable = true;

        }
    }

}