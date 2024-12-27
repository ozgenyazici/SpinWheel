using System;
using UnityEngine.UI;
using TMPro;
namespace CardGame
{
    public interface IButton
    {
        event Action OnButtonClicked;
        TextMeshProUGUI Text { get; set; }
        Button Button { get; set; }

    }

}