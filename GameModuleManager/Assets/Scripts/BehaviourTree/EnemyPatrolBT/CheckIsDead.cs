namespace RPG.BehaviourTree
{
    public class CheckIsDead : Node
    {
        private CharacterController _controller;

        public CheckIsDead(CharacterController controller)
        {
            _controller = controller;
        }

        public override NodeState Evaluate()
        {
            _state = _controller.IsDead ? NodeState.SUCCESS : NodeState.FAILURE;
            return _state;
        }
    }
}