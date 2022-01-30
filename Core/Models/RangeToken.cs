using Core.Interfaces;

namespace Core.Models
{
    public class RangeToken : IToken
    {
        public string Left { get; }
        public string Right { get; }

        public RangeToken(string left, string right)
        {
            Left = left;
            Right = right;
        }

        public override string ToString()
        {
            return $"{Left}-{Right}";
        }
    }
}