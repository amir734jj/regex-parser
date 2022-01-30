lexer grammar RegexLexer;

channels {
	ERROR
}

options {
	superClass = RegexLexerBase;
}

OpenParenToken: '(';
CloseParenToken: ')';
PipeToken: '|';
OpenBracketToken: '[';
CloseBracketToken: ']';
NegCharToken: '^';
DollarToken: '$';
AnyToken: '.';
PlusToken: '+';
StarToken: '*';
RangeToken: '-';
MetaCharToken: '\\'[a-zA-Z];
NonMetaCharToken: ~[\\];
UnexpectedCharacterToken: . -> channel(ERROR);