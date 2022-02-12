using System;
using System.Collections.Generic;
using Core.Interfaces;

namespace Core.Logic
{
    public class State
    {
        public IToken Token { get; }

        public readonly ISet<ITransition> IncomingTransitions = new HashSet<ITransition>();
        
        public State(IToken token)
        {
            Token = token;
        }

        public State AddIncomingEdge(ITransition transition)
        {
            IncomingTransitions.Add(transition);

            return this;
        }
    }
}