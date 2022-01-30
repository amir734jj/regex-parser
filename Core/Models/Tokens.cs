using Core.Interfaces;

namespace Core.Models
{
    public class Append : IToken
    {
        public IToken Left { get; }
        public IToken Right { get; }

        public Append(IToken left, IToken right)
        {
            Left = left;
            Right = right;
        }
    }
}