using System;
using System.Linq;
using Antlr4.Runtime.Tree;
using Core.Interfaces;
using Core.Models;

namespace Core
{
    public class RegexAstBuilder : RegexParserBaseVisitor<IToken>
    {
        public override IToken VisitRe(RegexParser.ReContext context)
        {
            if (context.union() != null)
            {
                return Visit(context.union());
            }

            if (context.simple_RE() != null)
            {
                return Visit(context.simple_RE());
            }
            
            throw new ArgumentException();
        }

        public override IToken VisitUnion(RegexParser.UnionContext context)
        {
            return new UnionToken(context.simple_RE().Select(Visit).ToArray());
        }

        public override IToken VisitSimple_RE(RegexParser.Simple_REContext context)
        {
            if (context.concatenation() != null)
            {
                return Visit(context.concatenation());
            }

            if (context.basic_RE() != null)
            {
                return Visit(context.basic_RE());
            }
            
            throw new ArgumentException();
        }

        public override IToken VisitConcatenation(RegexParser.ConcatenationContext context)
        {
            return new ConcatenationToken(context.basic_RE().Select(Visit).ToArray());
        }

        public override IToken VisitBasic_RE(RegexParser.Basic_REContext context)
        {
            if (context.star() != null)
            {
                return Visit(context.star());
            }

            if (context.plus() != null)
            {
                return Visit(context.plus());
            }
            
            if (context.elementary_RE() != null)
            {
                return Visit(context.elementary_RE());
            }

            throw new ArgumentException();
        }

        public override IToken VisitStar(RegexParser.StarContext context)
        {
            return new StarToken(Visit(context.elementary_RE()));
        }

        public override IToken VisitPlus(RegexParser.PlusContext context)
        {
            return new PlusToken(Visit(context.elementary_RE()));
        }

        public override IToken VisitElementary_RE(RegexParser.Elementary_REContext context)
        {
            if (context.group() != null)
            {
                return Visit(context.group());
            }

            if (context.any() != null)
            {
                return Visit(context.any());
            }
            
            if (context.eos() != null)
            {
                return Visit(context.eos());
            }
            
            if (context.@char() != null)
            {
                return Visit(context.@char());
            }
            
            if (context.set() != null)
            {
                return Visit(context.set());
            }

            throw new ArgumentException();
        }

        public override IToken VisitGroup(RegexParser.GroupContext context)
        {
            return new GroupToken(Visit(context.re()));
        }

        public override IToken VisitAny(RegexParser.AnyContext context)
        {
            return new AnyToken();
        }

        public override IToken VisitEos(RegexParser.EosContext context)
        {
            return new EosToken();
        }

        public override IToken VisitChar(RegexParser.CharContext context)
        {
            if (context.MetaCharToken() != null)
            {
                return new MetaCharToken(context.MetaCharToken().GetText());
            }
            
            if (context.NonMetaCharToken() != null)
            {
                return new MetaCharToken(context.NonMetaCharToken().GetText());
            }   

            throw new ArgumentException();
        }

        public override IToken VisitSet(RegexParser.SetContext context)
        {
            if (context.positive_set() != null)
            {
                return Visit(context.positive_set());
            }
            
            if (context.negative_set() != null)
            {
                return Visit(context.negative_set());
            }

            throw new ArgumentException();
        }

        public override IToken VisitPositive_set(RegexParser.Positive_setContext context)
        {
            return new PositiveToken(Visit(context.set_items()));
        }

        public override IToken VisitNegative_set(RegexParser.Negative_setContext context)
        {
            return new NegativeToken(Visit(context.set_items()));
        }

        public override IToken VisitSet_items(RegexParser.Set_itemsContext context)
        {
            if (context.range() != null)
            {
                return Visit(context.range());
            }

            if (context.NonMetaCharToken() != null)
            {
                return Visit(context.NonMetaCharToken());
            }

            if (context.MetaCharToken() != null)
            {
                return Visit(context.MetaCharToken());
            }

            throw new ArgumentException();
        }

        public override IToken VisitRange(RegexParser.RangeContext context)
        {
            string lhs;
            var rhs = Visit(context.@char());
            
            if (context.MetaCharToken() != null)
            {
                lhs = context.MetaCharToken().GetText();
            }
            else if (context.NonMetaCharToken() != null)
            {
                lhs = context.NonMetaCharToken().GetText();
            }
            else
            {
                throw new ArgumentException();
            }

            return rhs switch
            {
                MetaCharToken metaCharToken => new RangeToken(lhs, metaCharToken.Val),
                NonMetaCharToken nonMetaCharToken => new RangeToken(lhs, nonMetaCharToken.Val),
                _ => throw new ArgumentException()
            };
        }
    }
}