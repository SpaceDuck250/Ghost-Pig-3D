using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    [SerializeField]
    private bool paused = false;
    public GameObject pausePanel;

    private void Start()
    {
        Cursor.visible = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void Pause()
    {
        UISoundsScript.OnUIClick?.Invoke();


        if (paused)
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1;

            Cursor.visible = false;
        }
        else
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0;

            Cursor.visible = true;
        }

        paused = !paused;
    }

    public void GoToMainMenu()
    {
        UISoundsScript.OnUIClick?.Invoke();

        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        UISoundsScript.OnUIClick?.Invoke();


        print("Left the game");
        Application.Quit();
    }
}
