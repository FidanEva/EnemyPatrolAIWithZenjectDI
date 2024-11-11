using Character;
using EventModule;
using FSM.GameManager;
using UnityEngine;
using Zenject;

public class CharacterController : MonoBehaviour, ICharacter
{
    [Inject] private readonly GameManager _gameManager;
    
    [SerializeField] private UnityEngine.CharacterController builtinController;
    [SerializeField] private float speed = 10f;
    [SerializeField] private int health = 100;
    private float _cooldown;

    public int Health
    {
        get => health;
        set
        {
            health = value;
            if (health < 0)
            {
                _gameManager.ChangeState(GameState.GameOver);
                Destroy(gameObject);
            }
        }
    }

    private void Start()
    {
        EventBus.OnDirectionAxisUpdated += Move;
    }

    private void Move(Vector3 argDirection)
    {
        builtinController.Move(argDirection * (speed * Time.deltaTime));
    }

    private void OnDestroy()
    {
        EventBus.OnDirectionAxisUpdated -= Move;
    }

    public void Attack(ICharacter argCharacter)
    {
        _cooldown = 0f;
        if (_cooldown <= 0)
        {
            argCharacter.Health -= 10;
            _cooldown = 3f;
        }

        _cooldown -= Time.deltaTime;
    }

    // private void Update()
    // {
    //     var horizontalInput = Input.GetAxis("Horizontal");
    //     var verticalInput = Input.GetAxis("Vertical");
    //
    //     var direction = new Vector3(horizontalInput, 0, verticalInput) * (speed * Time.deltaTime);
    //     builtinController.Move(direction);
    // }
}