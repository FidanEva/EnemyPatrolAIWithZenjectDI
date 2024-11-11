using System.Collections.Generic;

namespace RPG.BehaviourTree
{
    public class Sequence : Node
    {
        public Sequence() : base()
        {
        }

        public Sequence(List<Node> children) : base(children)
        {
        }

        public override NodeState Evaluate()
        {
            var anyChildRunning = false;
            foreach (var child in _children)
            {
                switch (child.Evaluate())
                {
                    case NodeState.Running:
                        anyChildRunning = true;
                        break;
                    case NodeState.Success:
                        break;
                    case NodeState.Failure:
                        _state = NodeState.Failure;
                        return _state;
                    default:
                        _state = NodeState.Success;
                        return _state;
                }
            }

            _state = anyChildRunning ? NodeState.Running : NodeState.Success;
            return _state;
        }
    }
}