using System;

namespace Model
{
    public abstract class Transition : IUpdatable
    {
        private State _targetState;

        public event Action<State> NeedTransit;

        public Transition(State targetState)
        {
            if (targetState == null)
                throw new ArgumentNullException();

            _targetState = targetState;
        }

        public void Update(float deltaTime)
        {
            if (CheckNeedTransit(deltaTime) == true)
                NeedTransit?.Invoke(_targetState);
        }

        protected abstract bool CheckNeedTransit(float deltaTime);
    }
}