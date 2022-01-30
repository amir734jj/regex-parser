using Core.Interfaces;

namespace Core.Models
{
    public class MetaCharToken : IToken
    {
        public string Val { get; }

        public MetaCharToken(string val)
        {
            Val = val;
        }

        public override string ToString()
        {
            return $"\\{Val}";
        }
    }
}