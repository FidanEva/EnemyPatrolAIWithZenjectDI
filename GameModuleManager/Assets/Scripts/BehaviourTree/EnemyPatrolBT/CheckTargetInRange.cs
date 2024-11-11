using Character;
using UnityEngine;

namespace RPG.BehaviourTree
{
    public class CheckTargetInRange: Node
    {
        private LayerMask _targetMask;
        private Transform _transform;
        private float _fovRange;

        public CheckTargetInRange(
            LayerMask targetMask,
            Transform transform,
            float fovRange)
        {
            _targetMask = targetMask;
            _transform = transform;
            _fovRange = fovRange;
        }

        public override NodeState Evaluate()
        {
            var colliders = Physics.OverlapSphere(_transform.position, _fovRange, _targetMask);
            if (colliders.Length > 0)
            {
                Parent.Parent.SetData("Target", colliders[0].GetComponent<ICharacter>());

                _state = NodeState.Success;
                return _state;
            }

            _state = NodeState.Failure;
            return _state;
        }
    }
}