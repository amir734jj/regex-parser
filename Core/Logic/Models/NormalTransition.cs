using Core.Interfaces;

namespace Core.Logic
{
    public class NormalTransition : ITransition
    {
        private readonly char _accept;

        public NormalTransition(char accept)
        {
            _accept = accept;
        }
        
        public bool CanMove(char ch)
        {
            return ch == _accept;
        }

        public bool Move(char ch)
        {
            return true;
        }
    }
}