using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void PlayGame()
    {
        UISoundsScript.OnUIClick?.Invoke();

        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        UISoundsScript.OnUIClick?.Invoke();

        print("left");
        Application.Quit();
    }
}
