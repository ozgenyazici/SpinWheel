using UnityEngine;
using TMPro;

namespace CardGame
{
    public class RoundView : MonoBehaviour
    {
        public TextMeshProUGUI roundText;
        public void UpdateRoundText(int roundIndex)
        {
            roundText.text = "Round : " + roundIndex;
        }

    }

}