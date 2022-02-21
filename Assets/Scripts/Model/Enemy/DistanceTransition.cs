namespace Model
{
    public class DistanceTransition : Transition
    {
        private IPoint _model;
        private float _stoppingPoint;

        public DistanceTransition(IPoint model, float stoppingPoint, State targetState) : base(targetState)
        {
            _model = model;
            _stoppingPoint = stoppingPoint;
        }

        protected override bool CheckNeedTransit(float deltaTime)
        {
            return _model.Position.x < _stoppingPoint;
        }
    }
}