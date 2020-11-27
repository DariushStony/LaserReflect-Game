using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public GameObject LoadingPage;
    public Slider LoadingSilder;
    public Text LoadingText;

    public void LevelLoad(int SceneIndex)
    {
        //SceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        StartCoroutine(LoadAsynchronously(SceneIndex));
    }

    IEnumerator LoadAsynchronously (int SceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneIndex);

        LoadingPage.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            LoadingSilder.value = progress;
            LoadingText.text = LoadingText.text + (progress * 100f) + "%";

            Debug.Log(progress*100+"%");

            yield return null;
        }
    }

}
