using System.Collections.Generic;
using UnityEngine;

namespace RPG.BehaviourTree
{
    public class EnemyPatrolBT : Tree
    {
        [SerializeField] private LayerMask targetLayer;
        [SerializeField] private float fovRange;

        private EnemyController _enemyController;
        private CharacterController _characterController;

        public void Init(EnemyController controller)
        {
            _enemyController = controller;
        }

        protected override Node SetupTree()
        {
            var checkIsDead = new CheckIsDead(_characterController);
            var taskAttack = new TaskAttack(_characterController);
            var checkTargetInRange = new CheckTargetInRange(
                targetLayer, transform, fovRange);

            Sequence attack = new Sequence(new List<Node>
            {
                checkTargetInRange,
                taskAttack
            });

            Node root = new Selector(new List<Node>
            {
                checkIsDead,
                attack
            });

            return root;
        }
    }
}