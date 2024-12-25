using System.Collections;
using System;


namespace CardGame
{
    public class Player
    {
        private int totalRewards = 0;
        private int roundCount = 0;

        public void ResetRewards() { }
        public void AddReward(int amount)
        {
            totalRewards += amount;
        }
    }

}