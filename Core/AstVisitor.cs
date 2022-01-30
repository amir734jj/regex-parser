using System;
using Core.Interfaces;
using Core.Models;

namespace Core
{
    public abstract class AstVisitor<T>
    {
        public abstract T Visit(AnyToken anyToken);
        public abstract T Visit(ConcatenationToken concatenationToken);
        public abstract T Visit(EosToken eosToken);
        public abstract T Visit(GroupToken groupToken);
        public abstract T Visit(MetaCharToken metaCharToken);
        public abstract T Visit(NegativeToken negativeToken);
        public abstract T Visit(NonMetaCharToken nonMetaCharToken);
        public abstract T Visit(PlusToken plusToken);
        public abstract T Visit(PositiveToken positiveToken);
        public abstract T Visit(RangeToken rangeToken);
        public abstract T Visit(SetItems setItems);
        public abstract T Visit(StarToken starToken);
        public abstract T Visit(UnionToken unionToken);

        public T Visit(IToken token)
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