using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    [SerializeField]
    private bool paused = false;
    public GameObject pausePanel;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void Pause()
    {
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
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
