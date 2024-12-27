using System;
namespace CardGame
{
    public interface ICompleteable
    {
        event Action Completed;
    }
}