using Core.Interfaces;

namespace Core.Models
{
    public class PositiveToken : IToken
    {
        public IToken Token { get; }

        public PositiveToken(IToken token)
        {
            Token = token;
        }

        public override string ToString()
        {
            return $"[{Token}]";
        }
    }
}