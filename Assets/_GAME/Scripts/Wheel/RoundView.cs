namespace CardGame
{
    public class RoundView : BaseTextView
    {
        public override void UpdateText(string newText, int index=0)
        {
            textComponent.text = "Round " + newText;
        }
    }

   
}