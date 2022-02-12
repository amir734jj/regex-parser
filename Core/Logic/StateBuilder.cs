using System.Collections.Generic;
using System.Linq;
using Core.Interfaces;
using Core.Models;

namespace Core.Logic
{
    public class StateBuilder : AstVisitor<IDictionary<IToken, State>>
    {
        protected override IDictionary<IToken, State> Visit(AnyToken anyToken)
        {
            return new Dictionary<IToken, State> { { anyToken, new State(anyToken) } };
        }

        protected override IDictionary<IToken, State> Visit(ConcatenationToken concatenationToken)
        {
            return concatenationToken.Tokens
                .SelectMany(Visit).Concat(new KeyValuePair<IToken, State>[]
                    { new(concatenationToken, new State(concatenationToken)) })
                .ToDictionary(x => x.Key, x => x.Value);
        }

        protected override IDictionary<IToken, State> Visit(EosToken eosToken)
        {
            return new Dictionary<IToken, State> { { eosToken, new State(eosToken) } };
        }

        protected override IDictionary<IToken, State> Visit(GroupToken groupToken)
        {
            return Visit(groupToken.Token).Concat(new KeyValuePair<IToken, State>[]
                    { new(groupToken, new State(groupToken)) })
                .ToDictionary(x => x.Key, x => x.Value);
        }

        protected override IDictionary<IToken, State> Visit(MetaCharToken metaCharToken)
        {
            return new Dictionary<IToken, State> { { metaCharToken, new State(metaCharToken) } };
        }

        protected override IDictionary<IToken, State> Visit(NegativeToken negativeToken)
        {
            return Visit(negativeToken.Token).Concat(new KeyValuePair<IToken, State>[]
                    { new(negativeToken, new State(negativeToken)) })
                .ToDictionary(x => x.Key, x => x.Value);
        }

        protected override IDictionary<IToken, State> Visit(NonMetaCharToken nonMetaCharToken)
        {
            return new Dictionary<IToken, State> { { nonMetaCharToken, new State(nonMetaCharToken) } };
        }

        protected override IDictionary<IToken, State> Visit(PlusToken plusToken)
        {
            return Visit(plusToken.Token).Concat(new KeyValuePair<IToken, State>[]
                    { new(plusToken, new State(plusToken)) })
                .ToDictionary(x => x.Key, x => x.Value);
        }

        protected override IDictionary<IToken, State> Visit(PositiveToken positiveToken)
        {
            return Visit(positiveToken.Token).Concat(new KeyValuePair<IToken, State>[]
                    { new(positiveToken, new State(positiveToken)) })
                .ToDictionary(x => x.Key, x => x.Value);
        }

        protected override IDictionary<IToken, State> Visit(RangeToken rangeToken)
        {
            return new Dictionary<IToken, State> { { rangeToken, new State(rangeToken) } };
        }

        protected override IDictionary<IToken, State> Visit(SetItems setItems)
        {
            return setItems.Items
                .SelectMany(Visit).Concat(new KeyValuePair<IToken, State>[]
                    { new(setItems, new State(setItems)) })
                .ToDictionary(x => x.Key, x => x.Value);
        }

        protected override IDictionary<IToken, State> Visit(StarToken starToken)
        {
            return Visit(starToken.Token).Concat(new KeyValuePair<IToken, State>[]
                    { new(starToken, new State(starToken)) })
                .ToDictionary(x => x.Key, x => x.Value);
        }

        protected override IDictionary<IToken, State> Visit(UnionToken unionToken)
        {
            return unionToken.Tokens
                .SelectMany(Visit).Concat(new KeyValuePair<IToken, State>[]
                    { new(unionToken, new State(unionToken)) })
                .ToDictionary(x => x.Key, x => x.Value);
        }
    }
}