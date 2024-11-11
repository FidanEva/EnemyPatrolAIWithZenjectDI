using Character;
using UnityEngine;

namespace RPG.BehaviourTree
{
    public class CheckIsDead : Node
    {
        private ICharacter _controller;

        public CheckIsDead(ICharacter controller)
        {
            _controller = controller;
        }

        public override NodeState Evaluate()
        {
            _state = _controller.IsDead ? NodeState.Success : NodeState.Failure;
            return _state;
        }
    }
}