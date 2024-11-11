using UnityEngine;
using Zenject;
using FSM.GameManager.States;

namespace FSM.GameManager
{
    public class GameManager : MonoBehaviour
    {
        private GameStateFactory _gameStateFactory;

        private GameStateEntity _gameStateEntity = null;

        private GameState _currentGameState;
        private GameState _previousGameState;

        [Inject]
        public void Construct(GameStateFactory gameStateFactory)
        {
            _gameStateFactory = gameStateFactory;
        }

        private void Start()
        {
            ChangeState(GameState.Menu);
            DontDestroyOnLoad(this);
        }

        /// <summary>
        /// Changes the game state
        /// </summary>
        /// <param name="gameState">The state to transition to</param>
        internal void ChangeState(GameState gameState)
        {
            if (_gameStateEntity != null)
            {
                _gameStateEntity.Dispose();
                _gameStateEntity = null;
            }

            _previousGameState = _currentGameState;
            _currentGameState = gameState;

            _gameStateEntity = _gameStateFactory.CreateState(gameState);
            _gameStateEntity.Start();
        }
        
        public class Factory : PlaceholderFactory<GameManager>
        {
        }
    }
}