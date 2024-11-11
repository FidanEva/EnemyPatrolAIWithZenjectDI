using System.Collections.Generic;

namespace RPG.BehaviourTree
{
    public class Selector : Node
    {
        public Selector() : base()
        {
        }

        public Selector(List<Node> children) : base(children)
        {
        }

        public override NodeState Evaluate()
        {
            foreach (var child in _children)
            {
                switch (child.Evaluate())
                {
                    case NodeState.Running:
                        _state = NodeState.Running;
                        return _state;
                    case NodeState.Success:
                        _state = NodeState.Success;
                        return _state;
                    case NodeState.Failure:
                        continue;
                    default:
                        continue;
                }
            }

            _state = NodeState.Failure;
            return _state;
        }
    }
}