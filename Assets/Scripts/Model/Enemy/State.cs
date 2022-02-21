using System.Collections.Generic;

namespace Model
{
    public abstract class State : IUpdatable
    {
        public readonly IReadOnlyCollection<Transition> Transitions;
        
        public bool HasTransitions => Transitions != null;

        public State(params Transition[] transitions)
        {
            if(transitions.Length > 0)
            {
                Transitions = transitions;
            }
        }

        public void Update(float deltaTime)
        {
            if (Transitions != null)
            {
                foreach (var transition in Transitions)
                {
                    transition.Update(deltaTime);
                }
            }

            UpdateState(deltaTime);
        }

        protected virtual void UpdateState(float deltaTime) { }
    }
}
