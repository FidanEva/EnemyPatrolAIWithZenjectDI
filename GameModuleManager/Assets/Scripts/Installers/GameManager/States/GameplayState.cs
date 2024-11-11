using InputReader;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace FSM.GameManager.States
{
    public class GameplayState : GameStateEntity
    {
        [Inject] private InputModule _inputModule;

        public override void Initialize()
        {
            Debug.Log("GameplayState Initialized");
        }

        public override void Start()
        {
            Debug.Log("GameplayState Started");
            SceneManager.LoadScene(2);
            _inputModule.InputStrategy = new GamePlayInputStrategy() { InputModule = _inputModule };

        }

        public override void Tick()
        {
        }

        public override void Dispose()
        {
            Debug.Log("GameplayState Disposed");
        }

        public class Factory : Factory<GameplayState>
        {
        }
    }
}