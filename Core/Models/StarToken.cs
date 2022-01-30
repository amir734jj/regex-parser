using Core.Interfaces;

namespace Core.Models
{
    public class StarToken : IToken
    {
        public IToken Token { get; }

        public StarToken(IToken token)
        {
            Token = token;
        }

        public override string ToString()
        {
            return $"{Token}*";
        }
    }
}