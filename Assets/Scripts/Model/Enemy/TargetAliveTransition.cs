namespace Model
{
    public class TargetAliveTransition : Transition
    {
        private IHealth _target;

        public TargetAliveTransition(IHealth target, State targetState) : base(targetState)
        {
            _target = target;
        }

        protected override bool CheckNeedTransit(float deltaTime)
        {
            return _target.CurrentHealth <= 0;
        }
    }
}
