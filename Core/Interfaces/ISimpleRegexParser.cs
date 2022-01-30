
namespace Core.Interfaces
{
    public interface ISimpleRegexParser
    {
        IToken Parse(string text);
    }
}