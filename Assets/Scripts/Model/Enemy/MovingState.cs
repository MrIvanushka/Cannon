namespace Model
{
    public class MovingState : State
    {
        private Enemy _model;

        public MovingState(Enemy model, params Transition[] transitions) : base(transitions)
        {
            _model = model;
        }

        protected override void UpdateState(float deltaTime)
        {
            _model.MoveForward(deltaTime);   
        }
    }
}
