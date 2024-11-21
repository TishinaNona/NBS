﻿using System.Collections.Generic;

class StateNode
{
    public IState State { get; }

    public HashSet<ITransition> Transitions { get; }

    public StateNode(IState state)
    {
        State = state;
        Transitions = new HashSet<ITransition>();
    }

    public void AddTransition(IState to, IPredicate condition)
    {
        Transitions.Add(new Transition(to, condition));
    }
}