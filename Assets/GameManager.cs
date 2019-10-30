using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField]
    private LoadingMenuController loadingMenuController;

    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        StartCoroutine(LoadScene("MainGame"));
    }

    private IEnumerator LoadScene(string sceneName)
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
}
