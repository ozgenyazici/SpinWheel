using UnityEngine;
namespace CardGame
{
    public class ClaimButton : BaseButton
    {
        [SerializeField] private WheelManager wheelManager;

        private void Awake()
        {
            OnButtonClicked += ClaimRewards;
        }

        private void Update()
        {
            if (wheelManager.state == WheelManager.State.Spining)
                Button.interactable = false;
            else
                Button.interactable = true;

        }
        private void ClaimRewards()
        {
            GameManager.Instance.ClaimAllReward();
        }


    }

}