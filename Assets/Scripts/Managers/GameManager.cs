using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField]
    private LoadingMenuController loadingMenuController = default;

    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        StartCoroutine(LoadSceneAsync("MainGame"));
    }

    private IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);
        asyncOperation.allowSceneActivation = false;

        while (!asyncOperation.isDone)
        {
            loadingMenuController.SetLoadingProgress(asyncOperation.progress);
            if (asyncOperation.progress >= 0.9f)
            {
                asyncOperation.allowSceneActivation = true;
            }
            yield return null;
        }
    }

    public void LoadSceneSync(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
