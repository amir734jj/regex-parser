using System.Collections.Generic;
using System.Linq;
using Core.Interfaces;
using Core.Logic.Models;
using Core.Models;

namespace Core.Logic
{
    public class RegexToNfa : AstVisitor<State>
    {
        private readonly IDictionary<IToken, State> _states;

        public RegexToNfa(IDictionary<IToken, State> states)
        {
            _states = states;
        }
        
        protected override State Visit(AnyToken anyToken)
        {
            // Create a state that accepts any transition as incoming edge
            var state = _states[anyToken]
                .AddIncomingEdge(new AnyTransition());

            return state;
        }

        protected override State Visit(ConcatenationToken concatenationToken)
        {
            // Go through each child and connect states
            State prev = null;
            
            foreach (var token in concatenationToken.Tokens)
            {
                var childState = Visit(token);
                
                if (prev == null)
                {
                }
                else
                {
                    foreach (var childStateIncomingTransition in childState.IncomingTransitions)
                    {
                        childState.AddIncomingEdge(childStateIncomingTransition);
                    }

                    prev = childState;
                }
                
                prev = childState;

            }

            _states[concatenationToken].AddIncomingEdge(new EpsilonTransition());

            return _states[concatenationToken];
        }

        protected override State Visit(EosToken eosToken)
        {
            throw new System.NotImplementedException();
        }

        protected override State Visit(GroupToken groupToken)
        {
            throw new System.NotImplementedException();
        }

        protected override State Visit(MetaCharToken metaCharToken)
        {
            throw new System.NotImplementedException();
        }

        protected override State Visit(NegativeToken negativeToken)
        {
            throw new System.NotImplementedException();
        }

        protected override State Visit(NonMetaCharToken nonMetaCharToken)
        {
            throw new System.NotImplementedException();
        }

        protected override State Visit(PlusToken plusToken)
        {
            throw new System.NotImplementedException();
        }

        protected override State Visit(PositiveToken positiveToken)
        {
            throw new System.NotImplementedException();
        }

        protected override State Visit(RangeToken rangeToken)
        {
            throw new System.NotImplementedException();
        }

        protected override State Visit(SetItems setItems)
        {
            throw new System.NotImplementedException();
        }

        protected override State Visit(StarToken starToken)
        {
            var state = Visit(starToken.Token);

            _states[starToken].AddIncomingEdge(new EpsilonTransition());

            return state;
        }

        protected override State Visit(UnionToken unionToken)
        {
            throw new System.NotImplementedException();
        }
    }
}