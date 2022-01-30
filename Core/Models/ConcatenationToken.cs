using System;
using System.Linq;
using Core.Interfaces;

namespace Core.Models
{
    public class ConcatenationToken : IToken
    {
        public IToken[] Tokens { get; }

        public ConcatenationToken(IToken[] tokens)
        {
            Tokens = tokens;
        }

        public override string ToString()
        {
            return $"{string.Join("", Tokens.Select(x => x.ToString()))}";
        }
    }
}