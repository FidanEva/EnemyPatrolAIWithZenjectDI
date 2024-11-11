using InputReader;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace FSM.GameManager.States
{
    public class MenuState : GameStateEntity
    {
        [Inject] private InputModule _inputModule;

        public override void Initialize()
        {
            Debug.Log("MenuState Initialized");
        }

        public override void Start()
        {
            Debug.Log("MenuState Started");
            SceneManager.LoadScene(1);
            _inputModule.InputStrategy = new MenuInputStrategy() { InputModule = _inputModule };
        }

        public override void Tick()
        {
        }

        public override void Dispose()
        {
            Debug.Log("MenuState Disposed");
        }

        public class Factory : Factory<MenuState>
        {
        }
    }
}