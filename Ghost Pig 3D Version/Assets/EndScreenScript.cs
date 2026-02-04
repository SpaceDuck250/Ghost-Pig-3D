using UnityEngine;
using UnityEngine.SceneManagement;

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

        Cursor.visible = true;

        float waitTime = 0.4f;
        Invoke("GoBackToMainMenu", waitTime);
    }

    private void GoBackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
