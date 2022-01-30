using Antlr4.Runtime;
using Core.Interfaces;
using Microsoft.Extensions.Logging;
using IToken = Core.Interfaces.IToken;

namespace Core
{
    public class SimpleRegexParser : ISimpleRegexParser
    {
        private readonly ILogger<SimpleRegexParser> _logger;

        public SimpleRegexParser(ILogger<SimpleRegexParser> logger)
        {
            _logger = logger;
        }
        
        public IToken Parse(string text)
        {
            var str = CharStreams.fromString(text);

            var lexer = new RegexLexer(str);
            var tokens = new CommonTokenStream(lexer);
            var parser = new RegexParser(tokens);
            
            var listenerLexer = new ErrorListener<int>();
            var listenerParser = new ErrorListener<Antlr4.Runtime.IToken>();
            
            lexer.AddErrorListener(listenerLexer);
            parser.AddErrorListener(listenerParser);
            
            foreach (var token in lexer.GetAllTokens())
            {
                if (token.Channel == Lexer.DefaultTokenChannel)
                {
                    _logger.LogTrace("{%s}: {%s}", lexer.Vocabulary.GetSymbolicName(token.Type), token.Text);
                }
            }
            
            lexer.Reset();

            var tree = parser.re();

            var visitor = new RegexAstBuilder();

            return visitor.Visit(tree);
        }
    }
}