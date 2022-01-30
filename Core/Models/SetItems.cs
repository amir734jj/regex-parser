using System.Linq;
using Core.Interfaces;

namespace Core.Models
{
    public class SetItems : IToken
    {
        public IToken[] Items { get; }

        public SetItems(IToken[] items)
        {
            Items = items;
        }

        public override string ToString()
        {
            return string.Join("", Items.Select(x => x.ToString()));
        }
    }
}