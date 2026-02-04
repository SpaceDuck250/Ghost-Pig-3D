using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoaderScript : MonoBehaviour
{
    public GameObject startScreen;

    public float timeUntilStartScreen;

    private void Start()
    {
        Invoke("ShowStartScreen", timeUntilStartScreen);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GoToMainMenu();
        }
    }

    private void ShowStartScreen()
    {
        startScreen.SetActive(true);
    }

    private void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
