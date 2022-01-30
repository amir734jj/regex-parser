using System.Collections.Generic;
using Core.Interfaces;

namespace Core.Models
{
    public class SetItems : IToken
    {
        public List<IToken> Items { get; }

        public SetItems(List<IToken> items)
        {
            Items = items;
        }

        public override string ToString()
        {
            return string.Join("", Items);
        }
    }
}