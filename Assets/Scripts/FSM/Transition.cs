using System;

namespace PracticalWork2.FSM
{
    public class Transition
    {
        public BaseState ToState { get; }
        public Func<bool> Condition { get; }

        public Transition(BaseState toState, Func<bool> condition)
        {
            ToState = toState;
            Condition = condition;
        }
    }
}