using UnityEngine;
using TMPro;

namespace CardGame
{
    public abstract class BaseTextView : MonoBehaviour
    {
        public TextMeshProUGUI textComponent;

        private void OnValidate()
        {
            textComponent = GetComponent<TextMeshProUGUI>();
        }
        public abstract void UpdateText(string newText, int index);

    }
}