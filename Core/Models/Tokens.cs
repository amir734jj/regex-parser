using System.Linq;
using Core.Interfaces;

namespace Core.Models
{
    public class Append : IToken
    {
        public IToken[] Tokens { get; }
        
        public Append(IToken[] tokens)
        {
            Tokens = tokens;
        }

        public override string ToString()
        {
            return string.Join("", Tokens.Select(x => x.ToString()));
        }
    }
}