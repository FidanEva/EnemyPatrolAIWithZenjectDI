using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace RPG.BehaviourTree
{
    public class EnemyPatrolBT : Tree
    {
        [SerializeField] private LayerMask targetLayer;
        [SerializeField] private float fovRange;

        private EnemyController _enemyController;
        private CharacterController _characterController;

        [Inject]
        public void Construct(EnemyController enemyController, CharacterController characterController)
        {
            _enemyController = enemyController;
            _characterController = characterController;
        }

        protected override Node SetupTree()
        {
            var checkIsDead = new CheckIsDead(_enemyController);
            var taskAttack = new TaskAttack(_enemyController, _characterController);
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