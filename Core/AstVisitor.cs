using System;
using Core.Interfaces;
using Core.Models;

namespace Core
{
    public abstract class AstVisitor<T>
    {
        protected abstract T Visit(AnyToken anyToken);
        protected abstract T Visit(ConcatenationToken concatenationToken);
        protected abstract T Visit(EosToken eosToken);
        protected abstract T Visit(GroupToken groupToken);
        protected abstract T Visit(MetaCharToken metaCharToken);
        protected abstract T Visit(NegativeToken negativeToken);
        protected abstract T Visit(NonMetaCharToken nonMetaCharToken);
        protected abstract T Visit(PlusToken plusToken);
        protected abstract T Visit(PositiveToken positiveToken);
        protected abstract T Visit(RangeToken rangeToken);
        protected abstract T Visit(SetItems setItems);
        protected abstract T Visit(StarToken starToken);
        protected abstract T Visit(UnionToken unionToken);

        protected T Visit(IToken token)
        {
            return token switch
            {
                AnyToken anyToken => Visit(anyToken),
                ConcatenationToken concatenationToken => Visit(concatenationToken),
                EosToken eosToken => Visit(eosToken),
                GroupToken groupToken => Visit(groupToken),
                MetaCharToken metaCharToken => Visit(metaCharToken),
                NegativeToken negativeToken => Visit(negativeToken),
                NonMetaCharToken nonMetaCharToken => Visit(nonMetaCharToken),
                PlusToken plusToken => Visit(plusToken),
                PositiveToken positiveToken => Visit(positiveToken),
                RangeToken rangeToken => Visit(rangeToken),
                SetItems setItems => Visit(setItems),
                StarToken starToken => Visit(starToken),
                UnionToken unionToken => Visit(unionToken),
                _ => throw new ArgumentOutOfRangeException(nameof(token))
            };
        }
    }
}