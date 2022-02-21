namespace Model
{
    public class EnemyStateMachine : IUpdatable
    {
        private State _currentState;

        public EnemyStateMachine(State startState)
        {
            _currentState = startState;
            SubscribeToTransitions(_currentState);
        }

        ~EnemyStateMachine()
        {
            UnsubscribeOfTransitions(_currentState);
        }

        public void Update(float deltaTime)
        {
            _currentState.Update(deltaTime);
        }

        private void Transit(State nextState)
        {
            UnsubscribeOfTransitions(_currentState);
            SubscribeToTransitions(nextState);
            _currentState = nextState;
        }

        private void SubscribeToTransitions(State state)
        {
            if (state.HasTransitions == true)
            {
                foreach (var transition in state.Transitions)
                {
                    transition.NeedTransit += Transit;
                }
            }
        }

        private void UnsubscribeOfTransitions(State state)
        {
            if (state.HasTransitions == true)
            {
                foreach (var transition in state.Transitions)
                {
                    transition.NeedTransit -= Transit;
                }
            }
        }
    }
}

