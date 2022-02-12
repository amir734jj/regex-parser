using Core.Interfaces;

namespace Core.Logic.Models
{
    public class AnyTransition : ITransition
    {
        public bool CanMove(char ch)
        {
            return true;
        }

        public bool Move(char ch)
        {
            return true;
        }
    }
}