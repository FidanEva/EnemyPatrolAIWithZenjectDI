using Character;

namespace RPG.BehaviourTree
{
    public class TaskAttack : Node
    {
        private ICharacter _attackFrom;
        private ICharacter _attackTo;

        public TaskAttack(ICharacter attackFrom, ICharacter attackTp)
        {
            _attackFrom = attackFrom;
            _attackTo = attackTp;
        }

        public override NodeState Evaluate()
        {
            var target = (ICharacter)GetData("Target");
            if (_attackTo == target)
                _attackFrom.Attack(target);

            _state = NodeState.Running;
            return _state;
        }
    }
}