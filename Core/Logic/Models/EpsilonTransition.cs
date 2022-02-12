using Core.Interfaces;

namespace Core.Logic
{
    public class EpsilonTransition : ITransition
    {
        public bool CanMove(char ch)
        {
            return true;
        }

        public bool Move(char ch)
        {
            return false;
        }
    }
}