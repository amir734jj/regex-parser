using Core.Interfaces;

namespace Core.Models
{
    public class NegativeToken : IToken
    {
        public IToken Token { get; }

        public NegativeToken(IToken token)
        {
            Token = token;
        }
        
        public override string ToString()
        {
            return $"[^{Token}]";
        }
    }
}