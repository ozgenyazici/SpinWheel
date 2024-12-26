using System.Collections.Generic;
using System.Linq;


namespace CardGame
{
    public class RoundBasedSelection : IRewardSelection
    {
        public List<RewardDataSO> SelectRewards(List<RewardDataSO> rewards, int round)
        {
            return rewards.OrderByDescending(r => r.value).Take(8).ToList();
        }
    }

}