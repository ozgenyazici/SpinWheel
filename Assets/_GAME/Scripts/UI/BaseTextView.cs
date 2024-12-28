using UnityEngine;
using TMPro;

namespace CardGame
{
    public abstract class BaseTextView : MonoBehaviour
    {
        public TextMeshProUGUI textComponent;

        public abstract void UpdateText(string newText, int index);

    }
}