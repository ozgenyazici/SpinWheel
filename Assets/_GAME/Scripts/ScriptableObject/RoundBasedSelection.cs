using System.Collections.Generic;
using System.Linq;


namespace CardGame
{
    public class RoundBasedSelection : IRewardSelection
    {
        public List<Reward> SelectRewards(List<Reward> rewards, int round)
        {
            return rewards.OrderByDescending(r => r.rewardValue).Take(8).ToList();
        }
    }

}