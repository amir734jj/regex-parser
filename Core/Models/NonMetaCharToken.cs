using Core.Interfaces;

namespace Core.Models
{
    public class NonMetaCharToken : IToken
    {
        public string Val { get; }

        public NonMetaCharToken(string val)
        {
            Val = val;
        }

        public override string ToString()
        {
            return Val;
        }
    }
}