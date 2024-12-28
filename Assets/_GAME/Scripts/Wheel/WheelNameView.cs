using UnityEngine;
using TMPro;

namespace CardGame
{
    public class WheelNameView : BaseTextView, IChangeColor
    {
        public override void UpdateText(string newText, int index = 0)
        {
            textComponent.text = newText;
        }

        public void UpdateTextColor(Color newColor)
        {
            textComponent.color = newColor;
        }

    }

}