using Core.Interfaces;

namespace Core.Models
{
    public class PlusToken : IToken
    {
        public IToken Token { get; }

        public PlusToken(IToken token)
        {
            Token = token;
        }

        public override string ToString()
        {
            return $"{Token}+";
        }
    }
}