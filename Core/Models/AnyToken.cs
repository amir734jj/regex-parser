using Core.Interfaces;

namespace Core.Models
{
    public class AnyToken : IToken
    {
        public override string ToString()
        {
            return ".";
        }
    }
}