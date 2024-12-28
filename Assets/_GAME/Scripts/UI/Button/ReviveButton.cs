using UnityEngine;
namespace CardGame
{
    public class ReviveButton : BaseButton
    {
        [SerializeField] GoldCounter goldCounter;
        private const int amount = 10;
        private void Awake()
        {
            OnButtonClicked += ButtonClicked;
        }
        private void ButtonClicked()
        {
            goldCounter.OnRemoveGold(amount);

        }
    }

}