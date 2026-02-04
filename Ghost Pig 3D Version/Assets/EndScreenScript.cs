using UnityEngine;

public class EndScreenScript : MonoBehaviour
{
    public LevelManager levelManager;

    public static System.Action OnGameFinish;

    public GameObject endScreen;

    private void Start()
    {
        OnGameFinish += OnGameFinishFunction;
    }

    private void OnDestroy()
    {

        OnGameFinish -= OnGameFinishFunction;

    }

    private void OnGameFinishFunction()
    {
        endScreen.SetActive(true);

        print("DOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOG");
    }
}
