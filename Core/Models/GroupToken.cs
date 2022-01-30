using Core.Interfaces;

namespace Core.Models
{
    public class GroupToken : IToken
    {
        public IToken Token { get; }

        public GroupToken(IToken token)
        {
            Token = token;
        }

        public override string ToString()
        {
            return $"({Token})";
        }
    }
}