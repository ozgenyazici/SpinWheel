using System.Collections.Generic;


namespace CardGame
{
    public interface IRewardSelection
    {
        List<Reward> SelectRewards(List<Reward> rewards, int round);
    }

}