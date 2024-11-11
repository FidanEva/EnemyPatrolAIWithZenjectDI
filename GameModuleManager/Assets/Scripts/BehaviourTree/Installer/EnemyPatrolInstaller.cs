using Zenject;

namespace RPG.BehaviourTree.Installer
{
    public class EnemyPatrolInstaller : MonoInstaller<EnemyPatrolInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<EnemyController>().AsSingle();
            Container.Bind<CharacterController>().FromComponentInHierarchy().AsSingle();
            Container.Bind<EnemyPatrolBT>().FromComponentInHierarchy().AsSingle();
        }
    }
}