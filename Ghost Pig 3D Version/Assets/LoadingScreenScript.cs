using UnityEngine;
using System.Collections;

public class LoadingScreenScript : MonoBehaviour
{
    public GameObject loadingScreen;

    public float loadingTime;

    private void Start()
    {
        StartCoroutine(SetLoadingScreenOnFor(loadingTime));
    }

    private IEnumerator SetLoadingScreenOnFor(float time)
    {
        loadingScreen.SetActive(true);
        yield return new WaitForSeconds(time);
        loadingScreen.SetActive(false);

    }
}
