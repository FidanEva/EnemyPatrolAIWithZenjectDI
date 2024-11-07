using UnityEngine;

namespace RPG.BehaviourTree
{
    public class TaskAttack : Node
    {
        private CharacterController _controller;

        public TaskAttack(CharacterController controller)
        {
            _controller = controller;
        }

        public override NodeState Evaluate()
        {
            Transform t = (Transform)GetData("target");

            if (t.TryGetComponent(out EnemyController target))
                _controller.ProcessAttack(target);

            _state = NodeState.RUNNING;
            return _state;
        }
    }
}