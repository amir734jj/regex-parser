using Core.Interfaces;

namespace Core.Models
{
    public class EosToken : IToken
    {
        public override string ToString()
        {
            return "$";
        }
    }
}