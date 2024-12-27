using System;
namespace CardGame
{
    public interface IFailable
    {
        event Action Failed;
    }

}