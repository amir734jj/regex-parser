parser grammar RegexParser;

options {
	tokenVocab = RegexLexer;
	superClass = RegexParserBase;
}

// Source: https://www2.cs.sfu.ca/~cameron/Teaching/384/99-3/regexp-plg.html
            re : union
               | simple_RE EOF;
         union : simple_RE (PipeToken simple_RE)*;
     simple_RE : concatenation
               | basic_RE;
 concatenation : basic_RE basic_RE basic_RE*;
      basic_RE : star
               | plus
               | elementary_RE;
          star : elementary_RE StarToken;
          plus : elementary_RE PlusToken;
 elementary_RE : group
               | any
               | eos
               | char
               | set;
         group : OpenParenToken re CloseParenToken;
           any : AnyToken;
           eos : DollarToken;
          char : NonMetaCharToken
               | MetaCharToken;
           set : positive_set
               | negative_set;
  positive_set : OpenBracketToken set_items CloseBracketToken;
  negative_set : OpenBracketToken NegCharToken set_items CloseBracketToken;
     set_items : range
               | NonMetaCharToken
               | MetaCharToken;
         range : NonMetaCharToken RangeToken char
               | MetaCharToken RangeToken char;