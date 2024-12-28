using UnityEngine;

namespace CardGame
{
    public class WheelRewardView : BaseTextView, IChangeColor
    {
        public override void UpdateText(string newText, int index)
        {
            textComponent.text = "You got" + $" x{index} " + newText;
        }


        public void UpdateTextColor(Color newColor)
        {
            textComponent.color = newColor;
        }
    }

   
}