using System.Collections.Generic;


namespace CardGame
{
    public interface IRewardSelection
    {
        List<RewardDataSO> SelectRewards(List<RewardDataSO> rewards, int round);
    }

}