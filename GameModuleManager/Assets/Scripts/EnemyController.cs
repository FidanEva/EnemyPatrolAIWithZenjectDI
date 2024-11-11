using Character;
using FSM.GameManager;
using UnityEngine;
using Zenject;

public class EnemyController : ICharacter
{
    [Inject] readonly GameManager _gameManager;

    private float _cooldown;
    private int _health = 100;

    public int Health
    {
        get => _health;
        set
        {
            _health = value;
            if (_health <= 0)
            {
                _gameManager.ChangeState(GameState.Victory);
            }
        }
    }

    public void Attack(ICharacter argCharacter)
    {
        if (_cooldown <= 0)
        {
            argCharacter.Health -= 10;
            _cooldown = 3f;
        }

        _cooldown -= Time.deltaTime;
    }
}