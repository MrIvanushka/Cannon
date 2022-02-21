namespace Model
{
    public class AttackState : State
    {
        private Enemy _model;
        private float _delay;

        public AttackState(Enemy model, params Transition[] transitions) : base(transitions)
        {
            _model = model;
            _delay = _model.Cooldown;
        }

        protected override void UpdateState(float deltaTime)
        {
            _delay += deltaTime;

            if (_delay > _model.Cooldown)
            {
                _delay = 0;
                _model.Attack();
            }
        }
    }
}
