using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{

    public GameObject loadingScreen;
    public Slider slider;
    public Text text;
    public void LoadLevel(int indexScene)
    {
        StartCoroutine(LoadAsync(indexScene));
    }

    IEnumerator LoadAsync(int indexScene)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(indexScene);

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            slider.value = progress;
            text.text = progress * 100 + "%";
            yield return null;
        }
    } 
}
