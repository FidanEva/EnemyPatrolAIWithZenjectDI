using FSM.GameManager;
using UnityEngine;
using Zenject;

public class GameRunner : MonoBehaviour
{
    GameManager.Factory gameManagerFactory;

    [Inject]
    void Construct(GameManager.Factory bootstrapperFactory) =>
        this.gameManagerFactory = bootstrapperFactory;

    private void Awake()
    {
        var bootstrapper = FindObjectOfType<GameManager>();

        if (bootstrapper != null) return;

        gameManagerFactory.Create();
    }
}