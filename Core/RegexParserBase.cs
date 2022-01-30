// ReSharper disable once RedundantUsingDirective

using System.IO;
using Antlr4.Runtime;
// ReSharper disable PublicConstructorInAbstractClass
// ReSharper disable MemberCanBePrivate.Global

// ReSharper disable once CheckNamespace
// ReSharper disable once CheckNamespace
#pragma warning disable CA1050

public abstract class RegexParserBase : Parser
#pragma warning restore CA1050
{
    public RegexParserBase(ITokenStream input)
        : base(input)
    {
    }

    public RegexParserBase(ITokenStream input, TextWriter output, TextWriter errorOutput) : this(input)
    {
    }
}